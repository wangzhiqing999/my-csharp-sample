using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0020_Function.Sample
{
    class FunctionSample
    {


        /// <summary>
        /// 测试 “参数数量”可变的情况.
        /// </summary>
        /// <param name="list"></param>
        public void PrintAll(params Object[] list)
        {
            Console.WriteLine("测试函数 参数数量 可变的情况");
            foreach (Object obj in list)
            {
                Console.WriteLine(obj);
            }
        }


        /// <summary>
        /// 测试函数的 ref 关键字
        /// </summary>
        public void TestRef(ref int i)
        {
            Console.WriteLine("测试函数 ref 关键字");
            i++;
        }


        /// <summary>
        /// 测试函数的 out 关键字
        /// </summary>
        public void TestOut(out String st)
        {
            Console.WriteLine("测试函数 out 关键字");
            st = "OUT";
        }

    }
}
