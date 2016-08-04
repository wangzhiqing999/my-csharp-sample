using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sodao.FastSocket.Server;

namespace B0700_FastSocket_TelnetServer
{
    class Program
    {
        static void Main(string[] args)
        {

            SocketServerManager.Init();
            SocketServerManager.Start();

            Console.ReadLine();


        }
    }
}
