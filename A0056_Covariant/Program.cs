using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0056_Covariant.Sample;

namespace A0056_Covariant
{
    class Program
    {

        static void Main(string[] args)
        {

            Console.WriteLine("正常处理 : IEnumerable<父类> = List<父类>");
            // 正常处理.
            // IEnumerable<父类> = List<父类>
            List<TestParent> parentTestList = new List<TestParent>()
            {
                new TestParent() { Name = "ABC" },
                new TestParent() { Name = "DEF" },
                new TestParent() { Name = "GHI" },
            };
            PrintAll(parentTestList);


            Console.WriteLine("协变 : IEnumerable<父类> = List<子类>");
            // 协变
            // IEnumerable<父类> = List<子类>
            List<TestSub> subTestList = new List<TestSub>()
            {
                new TestSub() { Name = "123" },
                new TestSub() { Name = "456" },
                new TestSub() { Name = "789" },
            };
            PrintAll(subTestList);




            Console.WriteLine("正常处理 自定义接口<父类> = 自定义类<子类>");
            ICovariantAble<TestParent> p = new CovariantClass<TestParent>()
            {
                Data = new TestParent() { Name = "XYZ" },
            };
            p.PrintData();


            Console.WriteLine("正常处理 自定义接口<子类> = 自定义类<子类>");
            ICovariantAble<TestSub> s = new CovariantClass<TestSub>()
            {
                Data = new TestSub() { Name = "999" },
            };
            s.PrintData();


            // 协变
            Console.WriteLine("协变 自定义接口<父类> = 自定义接口<子类>");
            p = s;
            p.PrintData();

            Console.ReadLine();
        }


        static void PrintAll(IEnumerable<TestParent> testList)
        {
            foreach (TestParent data in testList)
            {
                data.PrintMe();
            }
        }

    }
}
