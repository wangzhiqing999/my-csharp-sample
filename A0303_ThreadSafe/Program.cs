using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0303_ThreadSafe.Sample;


namespace A0303_ThreadSafe
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("首先运行 不是 线程安全的 例子！");

            ThreadSampleNotSafe sample = new ThreadSampleNotSafe();

            ThreadStart tsa = new ThreadStart(sample.ThreadFuncA);
            ThreadStart tsb = new ThreadStart(sample.ThreadFuncB);

            Thread ta = new Thread(tsa);
            Thread tb = new Thread(tsb);

            ta.Start();
            tb.Start();
            
            Thread.Sleep(2000);



            Console.WriteLine("然后运行 使用 Monitor 实现 线程安全的 例子！");

            ThreadSampleWithMonitor sampleMonitor = new ThreadSampleWithMonitor();

            tsa = new ThreadStart(sampleMonitor.ThreadFuncA);
            tsb = new ThreadStart(sampleMonitor.ThreadFuncB);

            ta = new Thread(tsa);
            tb = new Thread(tsb);

            ta.Start();
            tb.Start();

            Thread.Sleep(2000);


            Console.WriteLine("然后运行 使用 lock 实现 线程安全的 例子！");

            ThreadSampleWithLock sampleLock = new ThreadSampleWithLock();

            tsa = new ThreadStart(sampleLock.ThreadFuncA);
            tsb = new ThreadStart(sampleLock.ThreadFuncB);

            ta = new Thread(tsa);
            tb = new Thread(tsb);

            ta.Start();
            tb.Start();

            Thread.Sleep(2000);



            Console.WriteLine("然后运行 使用 Mutex 实现 线程安全的 例子！");

            ThreadSampleWithMutex sampleMutex = new ThreadSampleWithMutex();

            tsa = new ThreadStart(sampleLock.ThreadFuncA);
            tsb = new ThreadStart(sampleLock.ThreadFuncB);

            ta = new Thread(tsa);
            tb = new Thread(tsb);

            ta.Start();
            tb.Start();

            Thread.Sleep(2000);



            Console.WriteLine("然后运行 使用 [MethodImpl(MethodImplOptions.Synchronized)] 实现 线程安全的 例子！");

            ThreadSampleWithMethodImplOptions sampleWithMethodImplOptions = new ThreadSampleWithMethodImplOptions();

            tsa = new ThreadStart(sampleWithMethodImplOptions.ThreadFuncA);
            tsb = new ThreadStart(sampleWithMethodImplOptions.ThreadFuncB);

            ta = new Thread(tsa);
            tb = new Thread(tsb);

            ta.Start();
            tb.Start();

            Thread.Sleep(2000);


            Console.ReadLine();
        }
    }
}
