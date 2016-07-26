using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Net;
using System.Net.Sockets;
using System.Threading;



namespace A0137_SocketServerPlus.Sample
{

    /// <summary>
    /// 服务器Listen.
    /// 
    /// 作用：接收客户端的请求。
    /// 每当接收到一个新的 客户端的 Socket 接入的时候， 创建一个 线程， 进行单独的处理.
    /// </summary>
    public class ServerListen
    {

        public static void Run()
        {
            // 本机预使用的IP和端口
            IPEndPoint serverIP = new IPEndPoint(IPAddress.Any, 1234);

            // 服务端 Socket.
            Socket skServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            skServer.Bind(serverIP);


            // 将 Socket 置于侦听状态。 队列最大100.
            skServer.Listen(100);


            while (true)
            {

                // 客户端 Socket.
                Socket skClient;
                try
                {
                    // 当有可用的客户端连接尝试时执行，并返回一个新的socket,用于与客户端之间的通信
                    skClient = skServer.Accept();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    continue;
                }


                // 将 服务器 Socket 与 客户端 Socket 作为参数，创建 针对 客户请求的处理.
                ThrClient thrC = new ThrClient(skServer, skClient);

                // 启动新线程.
                Thread t = new Thread(thrC.Run);
                t.Start();
            }
        }

    }

}
