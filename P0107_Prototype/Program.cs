using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0107_Prototype.Prototype;


namespace P0107_Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            Message mess = new Message()
            {
                From ="张三",
                To = "李四",
                Data = "Hello!"
            };

            MessageLog log = new MessageLog()
            {
                LogID = 1,
                Message = mess
            };

            Console.WriteLine("克隆前......");
            Console.WriteLine(log);
            Console.WriteLine();

            
            Console.WriteLine("浅层克隆后......");
            MessageLog log2 = log.SimpleClone();
            Console.WriteLine(log2);

            Console.WriteLine("修改克隆后数据，检查是否影响原始数据！");
            log2.Message.Data = "Hello V2.0";

            Console.WriteLine("原始数据={0}", log);
            Console.WriteLine("克隆数据={0}", log2);

            Console.WriteLine();




            Console.WriteLine("深层克隆后......");
            log2 = log.Clone() as MessageLog;
            Console.WriteLine(log2);

            Console.WriteLine("修改克隆后数据，检查是否影响原始数据！");
            log2.Message.Data = "Hello V3.0";

            Console.WriteLine("原始数据={0}", log);
            Console.WriteLine("克隆数据={0}", log2);

            Console.ReadLine();
        }
    }
}
