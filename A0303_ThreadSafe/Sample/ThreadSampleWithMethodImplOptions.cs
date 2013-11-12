using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.CompilerServices;


namespace A0303_ThreadSafe.Sample
{


    /// <summary>
    /// 这个例子 演示 使用 MethodImplOptions 来实现 线程 安全的操作。
    /// 
    /// 
    /// </summary>
    class ThreadSampleWithMethodImplOptions
    {



        /// <summary>
        /// 简单的 线程执行的 方法.
        /// 
        /// 这个方法不是 静态的
        /// 
        /// 这个方法是 线程安全的。
        /// </summary>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public void ThreadFunc(String keyword)
        {

            Console.WriteLine("线程{0}执行开始！", keyword);
            try
            {
                for (int i = 0; i < 60; i++)
                {
                    // 输出.
                    Console.Write(keyword);
                    Thread.Sleep(10);
                }
                Console.WriteLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("线程{0}执行结束！", keyword);
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
