using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace B0020_Log4Net_UdpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            TestShowLog();

            Console.WriteLine("Finish!");
            Console.ReadKey();
        }



        // 测试的例子代码.
        // 来源： http://logging.apache.org/log4net/release/sdk/html/T_log4net_Appender_UdpAppender.htm
        private static void TestShowLog()
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);
            UdpClient udpClient;
            byte[] buffer;
            string loggingEvent;

            try
            {
                udpClient = new UdpClient(8080);

                while (true)
                {
                    buffer = udpClient.Receive(ref remoteEndPoint);

                    // 这里使用的 Encoding.UTF8
                    // 取决于客户端的 UdpAppender 那里的 Encoding 属性.
                    // 两边要一致.
                    loggingEvent = Encoding.UTF8.GetString(buffer);

                    Console.WriteLine(loggingEvent);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

    }
}
