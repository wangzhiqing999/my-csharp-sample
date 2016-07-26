using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Threading;

using System.Net;
using System.Net.Sockets;


namespace A0146_SocketAsyncEventArgsClient.Sample
{

    /// <summary>
    /// 这个类为一个 Socket 客户端的例子.
    /// 这个类简单的 连接到 Socket 服务器，并发送一段消息。
    /// 然后读取来自服务器的反馈
    /// 最后结束程序.
    ///
    /// 服务端输出：
    /// 开始侦听 8088 端口……
    /// 接收到客户的连接
    /// 接收到来自客户端的数据为：Hello Socket Server!
    ///
    /// 客户端输出：
    /// 向服务器发送到了:Hello Socket Server!
    /// 从服务器接收到了:Hello Socket Server!
    ///
    /// </summary>
    class StockClient
    {

        /// <summary>
        /// 字符编码处理.
        /// </summary>
        private static readonly Encoding ASCII;


        /// <summary>
        /// 用于 发送/接收的端口.
        /// </summary>
        private const int PORT = 8088;


        private const String SEND_MESSAGE = "Hello Server {0}!";


        /// <summary>
        /// 客户端 Socket.
        /// </summary>
        private Socket clientSocket;

        /// <summary>
        /// 异步发送.
        /// </summary>
        private SocketAsyncEventArgs sendEventArg;


        /// <summary>
        /// 异步接受.
        /// </summary>
        private SocketAsyncEventArgs recvEventArg;



        // 构造用于发送的 字节缓冲.
        private byte[] sendBytes = new Byte[256];


        /// <summary>
        /// 用于接收的 字节缓冲.
        /// </summary>
        private byte[] recvBytes = new Byte[256];



        /// <summary>
        /// 发送消息队列
        /// </summary>
        private Queue<string> sendMessageQueue = new Queue<string>();



        public StockClient()
        {
            // 构造异步发送.
            sendEventArg = new SocketAsyncEventArgs();
            sendEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(Send_Completed);

            



            // 构造异步接受
            recvEventArg = new SocketAsyncEventArgs();
            recvEventArg.Completed += new EventHandler<SocketAsyncEventArgs>(Recv_Completed);
            // 设置要用于异步套接字方法的数据缓冲区。
            recvEventArg.SetBuffer(recvBytes, 0, recvBytes.Length);



        }



        static StockClient()
        {
            ASCII = Encoding.ASCII;
        }




        /// <summary>
        /// 发送完成.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Send_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                ShowSend(e);
            }
        }

        void ShowSend(SocketAsyncEventArgs e)
        {
            String str = ASCII.GetString(sendBytes, 0, e.BytesTransferred);

            Console.WriteLine("向服务器发送了数据:{0}", str);


            Thread.Sleep(500);

            // 尝试接收数据.
            bool willRaiseEvent = clientSocket.ReceiveAsync(recvEventArg);
            if (!willRaiseEvent)
            {
                ShowRecv(recvEventArg);
            }
        }






        /// <summary>
        /// 接收完成.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Recv_Completed(object sender, SocketAsyncEventArgs e)
        {
            if (e.BytesTransferred > 0 && e.SocketError == SocketError.Success)
            {
                ShowRecv(e);
            }

        }

        void ShowRecv(SocketAsyncEventArgs e)
        {            
            String str = ASCII.GetString(recvBytes, 0, e.BytesTransferred);
            Console.WriteLine("从服务器接收到了数据:{0}", str);




            if (sendMessageQueue.Count > 0)
            {
                // 队列中有数据需要发送.
                string mess = sendMessageQueue.Dequeue();


                sendBytes = ASCII.GetBytes(mess);

                sendEventArg.SetBuffer(sendBytes, 0, sendBytes.Length);

                bool willRaiseEvent = clientSocket.SendAsync(sendEventArg);
                if (!willRaiseEvent)
                {
                    ShowSend(sendEventArg);
                }
            }

        }





        public void SendMessage()
        {
            // IP地址.
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            // 接入点.
            IPEndPoint ephost = new IPEndPoint(localAddr, PORT);


            // 第一个参数：AddressFamily  = 指定 Socket 类的实例可以使用的寻址方案。
            //     Unspecified 未指定地址族。
            //     InterNetwork IP 版本 4 的地址。
            //     InterNetworkV6 IP 版本 6 的地址。
            //
            // 第二个参数：SocketType = 指定 Socket 类的实例表示的套接字类型。
            //     Stream 一个套接字类型，支持可靠、双向、基于连接的字节流，而不重复数据，也不保留边界。
            //            此类型的 Socket 与单个对方主机通信，并且在通信开始之前需要建立远程主机连接。
            //            此套接字类型使用传输控制协议 (Tcp)，AddressFamily 可以是 InterNetwork，也可以是 InterNetworkV6。
            //
            // 第三个参数：ProtocolType = 指定 Socket 类支持的协议。
            //     Tcp 传输控制协议 (TCP)。
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);







            try
            {
                //  尝试连接主机.
                clientSocket.Connect(ephost);


                bool willRaiseEvent = false;


                string mess = String.Format(SEND_MESSAGE, 0);

                sendBytes = ASCII.GetBytes(mess);

                sendEventArg.SetBuffer(sendBytes, 0, sendBytes.Length);


                int i = 1;

                while (i <= 10)
                {
                    mess = String.Format(SEND_MESSAGE, i);
                    // 数据入队列
                    sendMessageQueue.Enqueue(mess);
                    i++;
                }


                willRaiseEvent = clientSocket.SendAsync(sendEventArg);
                if (!willRaiseEvent)
                {
                    ShowSend(sendEventArg);
                }




                Console.WriteLine("按回车键 断开 Socket！");
                Console.ReadLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine("连接/发送/接收过程中，发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                clientSocket.Close();
            }
        }
    }
}
