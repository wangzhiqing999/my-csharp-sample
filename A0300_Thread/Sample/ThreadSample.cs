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
    /// 线程执行方法被定义为 普通方法
    /// </summary>
    class ThreadSample
    {

        /// <summary>
        /// 简单的 线程执行的 方法.
        /// 
        /// 这个方法不是 静态的
        /// </summary>
        public void ThreadFunc()
        {
            // 线程停止运行的标志位.
            Boolean done = false;

            // 计数器
            int count = 0;

            while (!done)
            {
                // 休眠2秒.
                Thread.Sleep(2000);

                // 计数器递增
                count++;

                // 输出.
                Console.WriteLine("[普通]执行次数：{0}", count);
            }
        }


        /// <summary>
        /// 启动线程的代码.
        /// 
        /// 
        /// 注意： 静态方法 与 普通方法 在多线程上的区别， 在于 普通方法 需要创建类的实例.
        /// </summary>
        public static void StartThread()
        {

            ThreadSample sample = new ThreadSample();
            ThreadStart ts = new ThreadStart(sample.ThreadFunc);

            Thread t = new Thread(ts);

            // 启动.
            t.Start();
        }

    }

}
