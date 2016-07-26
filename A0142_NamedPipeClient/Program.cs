using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0142_NamedPipeClient.Sample;


namespace A0142_NamedPipeClient
{
    class Program
    {
        static void Main(string[] args)
        {

            NamedPipeClient.StartClient();


            Console.WriteLine("按回车键结束！");
            Console.ReadLine();
        }

    }
}
