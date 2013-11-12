using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0130_SocketServer.Sample;


namespace A0130_SocketServer
{
    class Program
    {


        
        static void Main(string[] args)
        {

            // 构造 Socket 服务器对象.
            SocketServer server = new SocketServer();

            // 开始侦听.
            server.StartServer();


            Console.WriteLine("按回车键结束退出程序！");
            Console.ReadLine();
        }
    }
}
