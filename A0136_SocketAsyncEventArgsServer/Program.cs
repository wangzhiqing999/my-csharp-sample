using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;

using A0136_SocketAsyncEventArgsServer.Sample;


namespace A0136_SocketAsyncEventArgsServer
{
    class Program
    {
        static void Main(string[] args)
        {

            Server service = new Server(10, 32);

            // IP地址.
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");


            service.Init();

            service.Start(new IPEndPoint(localAddr, 8088));



        }
    }
}
