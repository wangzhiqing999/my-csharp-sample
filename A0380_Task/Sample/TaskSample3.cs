using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using System.Threading;


namespace A0380_Task.Sample
{
    class TaskSample3
    {

        public static async  void DoTest()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            Console.WriteLine("#{0} 主线程的方法处理开始！", Thread.CurrentThread.ManagedThreadId);

            await Test();


            stopwatch.Stop();
            Console.WriteLine("#{0} 主线程的方法处理结束！, 耗时：{1}", Thread.CurrentThread.ManagedThreadId, stopwatch.ElapsedMilliseconds);
        }




        static async Task Test()
        {
            Console.WriteLine("#{0} Test() 方法处理开始！", Thread.CurrentThread.ManagedThreadId);

            Task<int> t1 = GetVal(1);

            Task<int> t2 = GetVal(2);

            Task<int> t3 = GetVal(3);

            Console.WriteLine("#{0} Test() 方法处理结束！", Thread.CurrentThread.ManagedThreadId);



            // 注意:
            // 通常全套异步需要做一些额外的工作，下面是一些必须做的额外工作。
            // 当                            	不要使用							使用
            // 需要获得值的时候                 Task.Wait or Task.Result            await
            // 需要等待任何一个任务				Task.WaitAny                    	await Task.WhenAny
            // 需要等待所有任务完成				Task.WaitAll						await Task.WhenAll
            // 需要等待							Thread.Sleep						await Task.Delay


            await t1;
            await t2;
            await t3;


            

            Console.WriteLine("#{0} 处理结果： {1}, {2}, {3}", Thread.CurrentThread.ManagedThreadId, t1.Result, t2.Result, t3.Result);
        }



        private static Random random = new Random();


        static async Task<int> GetVal(int i)
        {
            Console.WriteLine("#{0} GetVal({1}) 方法处理开始！", Thread.CurrentThread.ManagedThreadId, i);
            
            await Task.Delay(i * 1000);
           
            Console.WriteLine("#{0} GetVal({1}) 方法处理结束！", Thread.CurrentThread.ManagedThreadId, i);

            return random.Next(100);            
        } 

    }
}
