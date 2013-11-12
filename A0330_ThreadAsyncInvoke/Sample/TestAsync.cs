using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace A0330_ThreadAsyncInvoke.Sample
{

    /// <summary>
    /// 用于测试  异步处理的类.
    /// </summary>
    public class TestAsync
    {

        #region 用于模拟长时间处理的方法.


        /// <summary>
        /// 一个 用于模拟长时间处理的 方法.
        /// 该方法简单返回2个参数的和.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        static int AsyncOperation(int x, int y)
        {
            Console.WriteLine("======#{0} 线程操作开始: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

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

            // 线程休眠 5000 毫秒.
            Thread.Sleep(5000);

            Console.WriteLine("======#{0} 线程操作结束: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

            return x + y;
        }



        /// <summary>
        /// 一个 用于模拟长时间处理的 方法.
        /// 该方法简单 休眠第2个参数的时间，
        /// 然后返回 第一个参数的 大写.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sleepTime"></param>
        /// <returns></returns>
        static string AsyncOperation2(string s, int sleepTime)
        {
            Console.WriteLine("======#{0} 线程操作开始: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

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

            // 休眠 参数指定的秒数.
            Thread.Sleep(sleepTime);

            Console.WriteLine("======#{0} 线程操作结束: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

            return s.ToUpper();
        }


        #endregion






        #region  异步处理的 调用方法.



        /// <summary>
        /// 简单异步调用测试.
        /// 
        /// 本方法 通过 启用2个异步处理.
        /// 
        /// 主线程 等待这2个异步处理都执行完毕后，输出这2个异步处理的执行结果.
        /// 
        /// </summary>
        public static void SimpleInvokeTest()
        {
            Console.WriteLine("==#{0}主线程处理开始：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));

            // 定义方法.
            var func = new Func<int, int, int>(AsyncOperation);

            // 异步调用1.
            var result1 = func.BeginInvoke(100, 200, null, null);
            // 异步调用2.
            var result2 = func.BeginInvoke(300, 400, null, null);

            // 主线程休眠 1000 毫秒.
            Thread.Sleep(1000);

            Console.WriteLine("==#{0}主线程处理结束：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));


            // 通过调用 EndInvoke 方法， 来获取 异步调用的处理结果.
            int result = func.EndInvoke(result1) + func.EndInvoke(result2);

            Console.WriteLine("==#{0}主线程获取的 异步操作结果：{1}",
                Thread.CurrentThread.ManagedThreadId,
                result);
            Console.WriteLine();
        }





        /// <summary>
        /// 本方法 通过 启用2个异步处理.
        /// 
        /// 等待 2个 异步处理中的任意一个执行完毕. 然后返回结果.
        /// 
        /// 此方式主要用于像下面这种情况：
        /// （比如有两个排序算法，它们哪个快取决于数据源，我们一起执行并且只要有一个得到结果就继续）
        /// 
        /// </summary>
        public static void WaitAnyTest()
        {
            Console.WriteLine("==#{0}主线程处理开始：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));

            // 定义方法.
            var func = new Func<string, int, string>(AsyncOperation2);

            // 异步调用.
            var result1 = func.BeginInvoke("hello ", 2000, null, null);
            var result2 = func.BeginInvoke("world ", 3000, null, null);


            Thread.Sleep(1000);

            Console.WriteLine("==#{0}主线程处理结束，等待2个 异步处理中的任意一个执行完毕：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));


            // 等待 2个 异步处理中的任意一个执行完毕.
            WaitHandle.WaitAny(
                new WaitHandle[] { 
                    result1.AsyncWaitHandle, 
                    result2.AsyncWaitHandle });

            // 判断 result1 异步执行是否执行完毕.
            string r1 = result1.IsCompleted ? func.EndInvoke(result1) : string.Empty;

            // 判断 result2 异步执行是否执行完毕.
            string r2 = result2.IsCompleted ? func.EndInvoke(result2) : string.Empty;
            
            

            if (string.IsNullOrEmpty(r1))
            {
                // 如果 r1 为空， 说明 异步调用处理过程中，result2 处理完成了。 result1 处理未完成.
                Console.WriteLine("==#{0} : 异步处理结果：{1}  {2}",
                    Thread.CurrentThread.ManagedThreadId,
                    r2,
                    DateTime.Now.ToString("hh:mm:ss"));

                //  让 result1 处理完成，并释放资源.
                func.EndInvoke(result1);
            }

            if (string.IsNullOrEmpty(r2))
            {
                // 如果 r2 为空， 说明 异步调用处理过程中，result1 处理完成了。 result2 处理未完成.
                Console.WriteLine("==#{0} : 异步处理结果：{1}  {2}",
                    Thread.CurrentThread.ManagedThreadId,
                    r1,
                    DateTime.Now.ToString("hh:mm:ss"));

                //  让 result2 处理完成，并释放资源.
                func.EndInvoke(result2);
            }

            Console.WriteLine();
        }





        /// <summary>
        /// 本方法 通过 启用1个异步处理.
        /// 
        /// 然后通过 周期的去 查询 IsCompleted 。
        /// 来判断异步处理是否完成.
        /// 
        /// </summary>
        public static void IsCompletedTest()
        {

            Console.WriteLine("==#{0}主线程处理开始：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));

            // 定义方法.
            var func = new Func<int, int, int>(AsyncOperation);

            // 异步调用.
            var result = func.BeginInvoke(100, 200, null, null);



            Thread.Sleep(1000);

            Console.WriteLine("==#{0}主线程处理结束：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));


            while (!result.IsCompleted)
            {
                Console.WriteLine("==#{0}主线程等待异步处理执行完毕：{1}",
                                Thread.CurrentThread.ManagedThreadId,
                                DateTime.Now.ToString("hh:mm:ss"));
                Thread.Sleep(500);
            }

            int r = func.EndInvoke(result);

            Console.WriteLine("==#{0}主线程获取的 异步操作结果：{1}",
                Thread.CurrentThread.ManagedThreadId,
                r);

            Console.WriteLine();
        }






        /// <summary>
        /// 本方法 通过 启用1个异步处理.
        ///  
        /// 通过定义回调的方式。
        /// 让异步处理执行完毕后，自行去调用回调处理的方法.
        /// </summary>
        public static void CallbackTest()
        {
            Console.WriteLine("==#{0}主线程处理开始：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));

            // 定义方法.
            var func = new Func<int, int, int>(AsyncOperation);

            // 异步调用，并设定 回调方法.
            var result = func.BeginInvoke(100, 200, CallbackMethod, func);

            Thread.Sleep(1000);


            Console.WriteLine("==#{0}主线程处理结束：{1}",
                            Thread.CurrentThread.ManagedThreadId,
                            DateTime.Now.ToString("hh:mm:ss"));

            Console.WriteLine();
        }


        /// <summary>
        /// 回调方法.
        /// </summary>
        /// <param name="ar"></param>
        private static void CallbackMethod(IAsyncResult ar)
        {
            Console.WriteLine("==#{0} 回调方法执行开始: {1}",
                Thread.CurrentThread.ManagedThreadId,
                DateTime.Now.ToString("hh:mm:ss"));

            var caller = (Func<int, int, int>)ar.AsyncState;

            int r = caller.EndInvoke(ar);

            Console.WriteLine("==#{0} 回调方法执行结束: {1}  {2}",
                Thread.CurrentThread.ManagedThreadId,
                r,
                DateTime.Now.ToString("hh:mm:ss"));

            Console.WriteLine();
        }



        #endregion



    }


}
