using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Sodao.FastSocket.Server;

namespace B0701_FastSocket_Server
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
