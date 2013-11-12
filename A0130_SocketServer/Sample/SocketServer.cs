using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

namespace A0130_SocketServer.Sample
{

    /// <summary>
    /// Socket 服务端例子
    /// 
    /// 这个例子仅仅处理一个 客户端的访问， 处理完毕后退出.
    /// 
    /// 
    /// 服务端的输出为：
    /// 
    /// 开始侦听 8088 端口……
    /// 接收到客户的连接
    /// 接收到来自客户端的数据为：1
    /// 
    /// 
    /// 
    /// 客户端的输入为：
    /// 
    /// telnet 127.0.0.1 8088
    ///  1
    /// 失去了跟主机的连接。
    /// 
    /// 
    /// </summary>
    class SocketServer
    {

        /// <summary>
        /// 字符编码处理.
        /// </summary>
        private static readonly Encoding ASCII;


        /// <summary>
        /// 用于 监听的端口.
        /// </summary>
        private const int PORT = 8088;


        static SocketServer()
        {
            ASCII = Encoding.ASCII;
        }

        public void StartServer()
        {
            TcpListener myListener = null;
            try
            {
                // IP地址.
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // 在 8088 端口 开一个侦听.
                myListener = new TcpListener(localAddr, PORT);

                // 开始侦听.
                myListener.Start();
                Console.WriteLine("开始侦听 {0} 端口……", PORT);

                // 程序在这里暂停， 等待客户端的接入.
                Socket mySocket = myListener.AcceptSocket();

                // 如果执行到这里，说明接收到了客户的连接.
                Console.WriteLine("接收到客户的连接");

                // 字节缓冲.
                Byte[] recvBytes = new Byte[256];

                // 读取数据到缓冲区当中
                Int32 bytes = mySocket.Receive(recvBytes, recvBytes.Length, SocketFlags.None);

                // 将缓冲区当中的 byte 数组，转化为 字符串.
                String str = ASCII.GetString(recvBytes, 0, bytes);

                Console.WriteLine("接收到来自客户端的数据为：{0}", str);

                // 将读取到的数据，发送回给客户端.
                mySocket.Send(recvBytes, bytes, SocketFlags.None);
                // 休眠5秒.
                Thread.Sleep(5000);
                // 关闭 Socket
                mySocket.Close();

            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {

                myListener.Stop();
            }
        }
    }
}
