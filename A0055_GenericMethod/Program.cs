using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0055_GenericMethod.Sample;

namespace A0055_GenericMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            // 测试 int 类型的.
            RandomOrder<int> intRandom = new RandomOrder<int>();

            List<int> intList = new List<int>()
            {
                1,2,3,4,5,6,7,8,9,10
            };

            List<int> intRandomList = intRandom.DoRandomOrder(intList);
            Console.WriteLine("Int 数据列表随机排序.");
            for (int i = 0; i < intRandomList.Count; i++)
            {
                Console.Write("{0}  ", intRandomList[i]);
            }
            Console.WriteLine();



            // 测试 string 类型的.
            RandomOrder<string> stringRandom = new RandomOrder<string>();

            List<string> stringList = new List<string>()
            {
                "A", "B", "C", "D", "E", "F", "G",
            };

            List<string> stringRandomList = stringRandom.DoRandomOrder(stringList);
            Console.WriteLine("string 数据列表随机排序.");
            for (int i = 0; i < stringRandomList.Count; i++)
            {
                Console.Write("{0}  ", stringRandomList[i]);
            }
            Console.WriteLine();



            Console.ReadLine();
        }
    }
}
