using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0104_Singleton.Sample;

namespace P0104_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("饿汉式 单例类 的处理！");

            for (int i = 0; i < 10; i++)
            {
                EagerSingleton data = EagerSingleton.GetInstance();
                Console.WriteLine(data.DemoCount++);
            }


            Console.WriteLine("懒汉式 单例类 的处理！");

            for (int i = 0; i < 10; i++)
            {
                LazySingleton data = LazySingleton.GetInstance();
                Console.WriteLine(data.DemoCount++);
            }

            Console.ReadLine();
        }
    }
}
