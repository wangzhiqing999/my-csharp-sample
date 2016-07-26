using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace A0131_UdpSocketServer.Sample
{

    /// <summary>
    /// UDP Socket 服务端.
    /// </summary>
    class UdpSocketServer
    {


        public static void SendData()
        {
            // 构造一个 UDP Socket.
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);


            // 广播方式发送.
            IPEndPoint iep1 = new IPEndPoint(IPAddress.Broadcast, 9050);//255.255.255.255

            // 指定 ip 地址发送.
            IPEndPoint iep2 = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);

            // 取得机器名.
            string hostname = Dns.GetHostName();

            // 转换为 待发送的数据.
            byte[] data = Encoding.ASCII.GetBytes(hostname);


            sock.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.Broadcast, 1);


            // 发送数据.
            sock.SendTo(data, iep1);

            sock.SendTo(data, iep2);


            // 关闭.
            sock.Close();
        }



    }
}
