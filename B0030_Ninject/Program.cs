using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject;



using B0030_Ninject.Sample;



namespace B0030_Ninject
{


    /// <summary>
    /// Ninject 最基础演示例子.
    /// 
    /// 
    /// 参考：
    /// 
    /// https://github.com/ninject/ninject/wiki/Injection-Patterns
    /// 
    /// </summary>
    class Program
    {


        static void Main(string[] args)
        {


            #region 不使用 Ninject 的方式.

            Console.WriteLine("不使用 Ninject 的方式.");

            // P1.
            People p1 = new People(new HelloWorldEnglish());
            p1.SayHello();

            // P2.
            People p2 = new People(new HelloWorldChinese());
            p2.SayHello();


            #endregion




            Console.WriteLine("####################");




            #region 使用 Ninject 的方式.


            Console.WriteLine("使用 Ninject 的方式.");



            using (IKernel kernel = new StandardKernel(new MyModules1()))
            {
                People p = kernel.Get<People>();
                p.SayHello();
            }


            using (IKernel kernel = new StandardKernel(new MyModules2()))
            {
                People p = kernel.Get<People>();
                p.SayHello();
            }



            #endregion




            Console.ReadLine();




        }



    }
}
