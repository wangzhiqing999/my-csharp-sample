using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0134_MemoryMappedFileServer.Sample;


namespace A0134_MemoryMappedFileServer
{
    class Program
    {
        static void Main(string[] args)
        {


            MemoryMappedFileServer.Test();



            Console.WriteLine("运行完毕，查看文件是否发生变化.");

            Console.ReadLine();

        }
    }
}
