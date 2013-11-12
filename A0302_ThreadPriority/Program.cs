using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0302_ThreadPriority.Sample;


namespace A0302_ThreadPriority
{
    class Program
    {
        static void Main(string[] args)
        {

            ThreadSample sample = new ThreadSample();

            ThreadStart tsa = new ThreadStart(sample.ThreadFuncA);
            ThreadStart tsb = new ThreadStart(sample.ThreadFuncB);

            Thread ta = new Thread(tsa);
            Thread tb = new Thread(tsb);

            
            // A 线程的 优先级 高于 B 线程
            // 在线程代码的 计数 中，A线程的 数值要大于 B线程。
            ta.Priority = ThreadPriority.Highest;
            tb.Priority = ThreadPriority.Lowest;


            // 启动.
            ta.Start();
            tb.Start();


            // 执行5秒以后， 结束
            Thread.Sleep(5000);


            ta.Abort();
            tb.Abort();

            Console.ReadLine();

        }
    }
}
