using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0300_Thread.Sample
{

    /// <summary>
    /// 最简单的 一个 线程的例子
    /// 
    /// 线程执行方法被定义为 静态方法
    /// </summary>
    class StaticThreadSample
    {

        /// <summary>
        /// 简单的 线程执行的 方法.
        /// 
        /// 这个方法是 静态的
        /// </summary>
        public static void ThreadFunc()
        {
            // 线程停止运行的标志位.
            Boolean done = false;

            // 计数器
            int count = 0;

            while (!done)
            {
                // 休眠1秒.
                Thread.Sleep(1000);

                // 计数器递增
                count++;

                // 输出.
                Console.WriteLine("[静态]执行次数：{0}", count);
            }
        }


        /// <summary>
        /// 启动线程的代码.
        /// </summary>
        public static void StartThread()
        {
            ThreadStart ts = new ThreadStart(ThreadFunc);
            Thread t = new Thread(ts);

            // 启动.
            t.Start();
        }

    }

}
