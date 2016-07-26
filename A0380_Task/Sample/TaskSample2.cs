using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;


namespace A0380_Task.Sample
{
    class TaskSample2
    {

        public static void DoTest()
        {
            Console.WriteLine("#{0} 主线程的方法处理开始！", Thread.CurrentThread.ManagedThreadId);

            // .NET 1.0开始就有的   
            new Thread(Go).Start();


            // .NET 4.0 引入了 TPL  
            Task.Factory.StartNew(Go);


            // .NET 4.5 新增了一个Run的方法  
            Task.Run(new Action(Go));

            Console.WriteLine("#{0} 主线程的方法处理结束！", Thread.CurrentThread.ManagedThreadId);
        }



        public static void Go()
        {
            Console.WriteLine("#{0} 子线程的方法处理开始！", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(1000);
            Console.WriteLine("#{0} 子线程的方法处理结束！", Thread.CurrentThread.ManagedThreadId);
        } 



    }


}
