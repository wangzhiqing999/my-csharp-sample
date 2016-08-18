using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Fleck;

namespace W2001_WebSocket_Fleck
{
    class Program
    {
        static void Main(string[] args)
        {


            // 创建一个 WebSocket 服务， 并启动它.
            var echoServer = new WebSocketServer("ws://127.0.0.1:8181/Echo");
            echoServer.Start(socket =>
            {
                socket.OnOpen = () => 
                {
                    Console.WriteLine("echoServer 连接打开.");
                };

                socket.OnClose = () =>
                {
                    Console.WriteLine("echoServer 连接关闭.");
                };

                socket.OnMessage = message =>
                {
                    Console.WriteLine("echoServer接收到客户端的请求：{0}, 简单原样返回.", message);
                    socket.Send(message);
                };

                socket.OnError = (error) =>
                {
                    Console.WriteLine("哎呀，echoServer 发生错误了......" + error.ToString());
                };

                socket.OnPing = (buff) =>
                {
                    Console.WriteLine("echoServer接收到 Ping ！");
                };

                socket.OnPong = (buff) =>
                {
                    Console.WriteLine("echoServer接收到 Pong ！");
                };

            });



            var demoServer = new WebSocketServer("ws://127.0.0.1:8182/Demo");
            demoServer.Start(socket =>
            {
                DemoService service = null;

                socket.OnOpen = () =>
                {
                    Console.WriteLine("demoServer 连接打开.");

                    service = new DemoService()
                    {
                        Socket = socket
                    };
                    service.Start();
                };

                socket.OnClose = () =>
                {
                    Console.WriteLine("demoServer 连接关闭.");

                    if (service != null)
                    {
                        service.Stop();
                    }                    
                };

                socket.OnMessage = message =>
                {
                    Console.WriteLine("demoServer 接收到客户端的请求：{0}, 不做任何返回.", message);


                };

                socket.OnError = (error) =>
                {
                    Console.WriteLine("哎呀，demoServer 发生错误了......" + error.ToString());
                };

                socket.OnPing = (buff) =>
                {
                    Console.WriteLine("demoServer接收到 Ping ！");
                };

                socket.OnPong = (buff) =>
                {
                    Console.WriteLine("demoServer接收到 Pong ！");
                };
            });




            Console.WriteLine("按回车键结束程序...");
            Console.ReadLine();

        }




    }



    class DemoService 
    {

        public DemoService()
        {
            Console.WriteLine("初始化 Demo 服务.");
        }

        /// <summary>
        /// Socket.
        /// </summary>
        public IWebSocketConnection Socket { set; get; }


        /// <summary>
        /// 线程停止运行的标志位
        /// </summary>
        private bool done;


        public void ThreadFunc()
        {
            Console.WriteLine("线程开始...");

            // 计数器
            int count = 0;

            while (!done)
            {
                // 休眠2秒.
                Thread.Sleep(2000);

                // 计数器递增
                count++;


                // 输出.
                if (Socket.IsAvailable) {
                    Socket.Send(String.Format("[普通]执行次数：{0}", count));
                }
                else
                {
                    Console.WriteLine("Socket 好像不可用的样子...");
                }
                
            }

            Console.WriteLine("线程结束...");
        }


        public void Start()
        {
            ThreadStart ts = new ThreadStart(ThreadFunc);
            Thread t = new Thread(ts);
            // 启动.
            t.Start();
        }

        public void Stop()
        {
            done = true;
        }

    }
}
