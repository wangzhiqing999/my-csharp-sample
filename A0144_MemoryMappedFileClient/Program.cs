using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0144_MemoryMappedFileClient.Sample;


namespace A0144_MemoryMappedFileClient
{
    class Program
    {
        static void Main(string[] args)
        {

            MemoryMappedFileClient.Test();


            Console.WriteLine("运行完毕，待主程序关闭后，查看文件是否发生相应变化.");
            Console.ReadLine();

        }
    }
}
