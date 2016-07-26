using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;

namespace A0141_UpdSocketClient.Sample
{
    class UpdSocketClient
    {
        public static void ReceiveData()
        {

            // 构造一个 UDP Socket.
            Socket sock = new Socket(AddressFamily.InterNetwork,   SocketType.Dgram, ProtocolType.Udp);

            // 监听的地址与短裤.
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 9050);

            sock.Bind(iep);



            EndPoint ep = (EndPoint)iep;

            Console.WriteLine("Ready to receive…");



            // 暂存数据的 byte 数组.
            byte[] data = new byte[1024];

            // 读取数据.
            int recv = sock.ReceiveFrom(data, ref ep);

            // 格式化为字符串.
            string stringData = Encoding.ASCII.GetString(data, 0, recv);


            Console.WriteLine("received: {0} from: {1}", stringData, ep.ToString());



            data = new byte[1024];

            // 读取数据.
            recv = sock.ReceiveFrom(data, ref ep);

            stringData = Encoding.ASCII.GetString(data, 0, recv);

            Console.WriteLine("received: {0} from: {1}", stringData, ep.ToString());

            sock.Close();

        }
    }
}
