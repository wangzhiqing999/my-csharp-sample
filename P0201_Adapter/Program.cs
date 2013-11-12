using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0201_Adapter.Target;
using P0201_Adapter.Adapter;

namespace P0201_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== 类的适配器 =====");
            TestClassAdapter();

            Console.WriteLine("===== 对象的适配器 =====");
            TestObjectAdapter();


            Console.ReadLine();
        }




        private static void TestClassAdapter()
        {
            ITarget t = new ClassAdapter();
            t.SayHelloworld();
            t.SayGoodbye();
        }


        private static void TestObjectAdapter()
        {
            ITarget t = new ObjectAdapter();
            t.SayHelloworld();
            t.SayGoodbye();
        }

    }
}
