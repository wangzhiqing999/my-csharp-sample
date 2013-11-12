using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;


namespace A0140_SocketClient.Sample
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


        private const String SEND_MESSAGE = "Hello Socket Server!";


        static StockClient()
        {
            ASCII = Encoding.ASCII;
        }

        public void SendMessage()
        {
            // 构造用于发送的 字节缓冲.
            Byte[] sendBytes = ASCII.GetBytes(SEND_MESSAGE);

            // 构造用于接收的 字节缓冲.
            Byte[] recvBytes = new Byte[256];

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
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                //  尝试连接主机.
                s.Connect(ephost);


                Console.WriteLine("向服务器发送到了:{0}", SEND_MESSAGE);

                // 向主机发送数据.
                s.Send(sendBytes, sendBytes.Length, SocketFlags.None);

                // 接收服务器的应答.
                Int32 bytes = s.Receive(recvBytes, recvBytes.Length, SocketFlags.None);


                StringBuilder buff = new StringBuilder();

                while (bytes > 0)
                {
                    // 将缓冲的字节数组，装换为字符串.
                    String str = ASCII.GetString(recvBytes, 0, bytes);
                    // 加入字符串缓存
                    buff.Append(str);
                    // 再次接受，看看后面还有没有数据.
                    bytes = s.Receive(recvBytes, recvBytes.Length, SocketFlags.None);
                }

                Console.WriteLine("从服务器接收到了:{0}", buff.ToString());


            }
            catch (Exception ex)
            {
                Console.WriteLine("连接/发送/接收过程中，发生了错误！");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            finally
            {
                s.Close();
            }
        }
    }
}
