using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A5300_UDP_P2P.Service;


namespace A5300_UDP_P2P
{
    class Program
    {
        static void Main(string[] args)
        {
            P2PService service = new P2PService();

            service.Start();


            Console.WriteLine("按回车键结束！");
            Console.ReadLine();
        }
    }
}
