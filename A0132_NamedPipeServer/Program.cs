using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0132_NamedPipeServer.Sample;



namespace A0132_NamedPipeServer
{
    class Program
    {
        static void Main(string[] args)
        {

            NamedPipeServer.StartServerThread();


            Console.WriteLine("按回车键结束！");
            Console.ReadLine();

        }
    }
}
