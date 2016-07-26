using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0131_UdpSocketServer.Sample;

namespace A0131_UdpSocketServer
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpSocketServer.SendData();

            Console.WriteLine("Finish!");
            Console.ReadLine();
        }
    }
}
