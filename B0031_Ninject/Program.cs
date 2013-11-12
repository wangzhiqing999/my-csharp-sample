using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Ninject;



using B0031_Ninject.Sample;




namespace B0031_Ninject
{


    /// <summary>
    /// 
    /// 本例子用于 测试 Multi injection 。 也就是 注入的 是一个集合。
    /// 
    /// 
    /// 参考资料页面：
    /// 
    /// https://github.com/ninject/ninject/wiki/Multi-injection
    /// 
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("本例子用于 测试 Multi injection 。 也就是 注入的 是一个集合。");


            using (IKernel kernel = new StandardKernel(new MyModules()))
            {
                People2 p = kernel.Get<People2>();
                p.SayHello();
            }



            Console.ReadLine();
        }

        
    }



}
