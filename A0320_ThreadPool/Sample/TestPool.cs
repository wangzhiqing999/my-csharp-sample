using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;


namespace A0320_ThreadPool.Sample
{

    public class TestPool
    {


        // 测试方法.
        public static void TestThreadPool()
        {
            // 设置线程池的最小数.
            ThreadPool.SetMinThreads(2, 2);

            // 设置线程池的最大数.
            ThreadPool.SetMaxThreads(5, 5);


            // 向线程池加入 10个处理任务.
            for (int i = 0; i < 10; i++)
            {
                // 向线程池加入处理， 参数为 i.
                ThreadPool.QueueUserWorkItem(new WaitCallback(LongTimeOperation), i);
            }

        }





        /// <summary>
        /// 一个 用于模拟长时间处理的 方法.
        /// </summary>
        /// <param name="stateInfo"></param>
        private static void LongTimeOperation(Object stateInfo)
        {
            Console.WriteLine("======#{0} 线程操作开始: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

            Console.WriteLine("======#{0} 线程参数: {1}",
                Thread.CurrentThread.ManagedThreadId,
                stateInfo);


            // 可用辅助线程的数目。 
            int workerThreads;
            // 可用异步 I/O 线程的数目。
            int completionPortThreads;

            // 检索由 GetMaxThreads 方法返回的最大线程池线程数和当前活动线程数之间的差值.
            ThreadPool.GetAvailableThreads(out workerThreads, out completionPortThreads);

            Console.WriteLine("======#{0}(可用辅助线程{1} | 可用异步 I/O 线程{2})",
                Thread.CurrentThread.ManagedThreadId,
                workerThreads,
                completionPortThreads);

            // 线程休眠 2000 毫秒.
            Thread.Sleep(2000);

            Console.WriteLine("======#{0} 线程操作结束: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

            Console.WriteLine();
        }



    }


}
