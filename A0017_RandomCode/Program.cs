using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0017_RandomCode.Sample;

namespace A0017_RandomCode
{
    class Program
    {
        static void Main(string[] args)
        {

            RandomCodeCreater c1 = new RandomCodeCreater()
            {
                 CodeCharType =  RandomCodeCreater.CodeUseCharType.NumberCode,
                 CodeLength = 5
            };

            // 生成 10 个
            HashSet<string> resultSet1 = c1.CreateRandomCode(10);

            foreach (string oneResult in resultSet1)
            {
                Console.WriteLine("数字Only 长度5 ==> {0}", oneResult);
            }



            RandomCodeCreater c2 = new RandomCodeCreater()
            {
                CodeCharType = RandomCodeCreater.CodeUseCharType.NumberCode | RandomCodeCreater.CodeUseCharType.UpperCode,
                CodeLength = 5
            };

            // 生成 10 个
            HashSet<string> resultSet2 = c2.CreateRandomCode(10);

            foreach (string oneResult in resultSet2)
            {
                Console.WriteLine("数字 或者 大写字母 长度5 ==> {0}", oneResult);
            }



             RandomCodeCreater c3 = new RandomCodeCreater()
            {
                CodeCharType = RandomCodeCreater.CodeUseCharType.NumberCode | RandomCodeCreater.CodeUseCharType.UpperCode | RandomCodeCreater.CodeUseCharType.LowerCode,
                CodeLength = 5
            };

            // 生成 10 个
            HashSet<string> resultSet3 = c3.CreateRandomCode(10);

            foreach (string oneResult in resultSet3)
            {
                Console.WriteLine("数字 或者 大写字母 或者 小写字母 长度5 ==> {0}", oneResult);
            }



            Console.WriteLine("##### 尝试模拟 已经存在有 50 个 随机码的情况下， 再生成 30 个的情况 ##### ");

            RandomCodeCreater c4 = new RandomCodeCreater()
            {
                CodeCharType = RandomCodeCreater.CodeUseCharType.NumberCode,
                CodeLength = 2
            };


            // 先生成 50 个
            Console.WriteLine("##### 先50个 #####");
            HashSet<string> resultSet4A = c4.CreateRandomCode(50);
            foreach (string oneResult in resultSet4A)
            {
                Console.WriteLine("数字 长度2 ==> {0}", oneResult);
            }

            Console.WriteLine("##### 再30个 #####");
            HashSet<string> resultSet4B = c4.CreateRandomCode(30);
            foreach (string oneResult in resultSet4B)
            {
                Console.WriteLine("数字 长度2 ==> {0}", oneResult);
            }


            Console.ReadLine();

        }
    }
}
