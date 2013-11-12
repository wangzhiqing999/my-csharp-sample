using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0080_checked.Sample;

namespace A0080_checked
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCheckedSample sample = new TestCheckedSample();

            short s1 = 32767;
            short s2 = 32767;

            Console.WriteLine("使用 checked 关键字， 进行运算 {0} + {1} = {2}", s1, s2, sample.CheckAdd(s1, s2));
            Console.WriteLine("不使用 checked 关键字， 进行运算 {0} + {1} = {2}", s1, s2, sample.UnCheckAdd(s1, s2));

            Console.ReadLine();
        }
    }
}
