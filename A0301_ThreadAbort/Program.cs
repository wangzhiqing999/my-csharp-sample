using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0301_ThreadAbort.Sample;


namespace A0301_ThreadAbort
{


    /// <summary>
    /// 这个例子用于 演示  如何 中止 线程操作。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            ThreadSample sample = new ThreadSample();
            ThreadStart ts = new ThreadStart(sample.ThreadFunc);

            Thread t = new Thread(ts);

            // 启动.
            t.Start();


            // 线程启动10秒以后，终止执行
            Thread.Sleep(10000);

            t.Abort();

            Console.ReadLine();
        }

    }
}
