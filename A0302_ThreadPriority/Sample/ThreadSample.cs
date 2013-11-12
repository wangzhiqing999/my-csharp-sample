using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0302_ThreadPriority.Sample
{
    class ThreadSample
    {
        /// <summary>
        /// 简单的 线程执行的 方法.
        /// 
        /// 这个方法不是 静态的
        /// </summary>
        public void ThreadFunc(String keyword)
        {
            Console.WriteLine("线程执行开始！");
            try
            {
                // 线程停止运行的标志位.
                Boolean done = false;

                // 计数器
                int count = 0;

                while (!done)
                {
                    // 计数器递增
                    count++;
                    // 输出.
                    Console.WriteLine("[{1}]执行次数：{0}", count, keyword);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("线程执行结束！");
            }
        }



        public void ThreadFuncA()
        {
            ThreadFunc("A");
        }

        public void ThreadFuncB()
        {
            ThreadFunc("B");
        }


    }
}
