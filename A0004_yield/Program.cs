using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using A0004_yield.Sample;

namespace A0004_yield
{
    class Program
    {
        static void Main(string[] args)
        {

            TestYield test = new TestYield();

            Console.WriteLine("测试不使用 yield 的例子！");
            Console.WriteLine("==开始时间:{0}", DateTime.Now);
            foreach (int data in test.GetDataListWithoutYield())
            {
                Console.WriteLine("====处理时间:{0},  处理结果:{1}", DateTime.Now, data);

                if(data == 6)
                {
                    Console.WriteLine("====== 当返回 6 的时候，中断处理！");
                    break;
                }
            }
            Console.WriteLine("==结束时间:{0}", DateTime.Now);



            Console.WriteLine();
            Console.WriteLine("测试使用 yield 的例子！");
            Console.WriteLine("==开始时间:{0}", DateTime.Now);
            foreach (int data in test.GetDataListWithYield())
            {
                Console.WriteLine("====处理时间:{0},  处理结果:{1}", DateTime.Now, data);

                if (data == 6)
                {
                    Console.WriteLine("====== 当返回 6 的时候，中断处理！");
                    break;
                }
            }
            Console.WriteLine("==结束时间:{0}", DateTime.Now);


            Console.ReadLine();
        }
    }
}
