using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

using Ninject;

using B0030_Ninject.Sample;


namespace B0032_Ninject
{

    /// <summary>
    /// Ninject   Object Scopes 演示例子.
    /// 
    /// 
    /// 也就是  普通的范围、 单例的范围、 线程的范围。
    /// 
    /// 参考：
    /// 
    /// https://github.com/ninject/ninject/wiki/Object-Scopes
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {



            Console.WriteLine("测试 InTransientScope 的处理！");

            using (IKernel kernel = new StandardKernel(new MyModulesInTransientScope()))
            {
                for (int i = 0; i < 5; i++)
                {
                    People p = kernel.Get<People>();
                    p.SayHello();
                }
            }

            Console.WriteLine();





            Console.WriteLine("测试 InSingletonScope 的处理！");

            using (IKernel kernel = new StandardKernel(new MyModulesInSingletonScope()))
            {
                for (int i = 0; i < 5; i++)
                {
                    People p = kernel.Get<People>();
                    p.SayHello();
                }
            }

            Console.WriteLine();






            Console.WriteLine("测试 InThreadScope 的处理！");

            // 因为开多线程了， 不适合用 using 了
            // 否则线程还没执行完，Kernel 就释放掉了.
            IKernel threadKernel = new StandardKernel(new MyModulesInThreadScope());            
            // 开 3 个线程，  每个线程创建 3 次.
            for (int i = 0; i < 3; i++)
            {
                new Thread(() =>
                {
                    for (int j = 0; j < 3; j++)
                    {

                        People p = threadKernel.Get<People>();
                        p.SayHello();
                    }
                }).Start();
            }


            

            Console.WriteLine();



            Console.ReadLine();
        }
    }
}
