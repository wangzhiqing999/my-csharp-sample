using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Ninject;

using B0030_Ninject.Sample;
using B0033_Ninject.Sample;


namespace B0033_Ninject
{


    /// <summary>
    /// 测试  Ninject  中的  Contextual Binding
    /// 
    /// 
    /// 
    /// 
    /// https://github.com/ninject/ninject/wiki/Contextual-Binding
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("通过 命名方式， 获取指定的实例!");

            using (IKernel kernel = new StandardKernel(new MyModulesByName()))
            {
                Console.WriteLine("获取 ChinesePeople ( Chinese 定义在 ChinesePeople 类中 ) ！");
                ChinesePeople cp = kernel.Get<ChinesePeople>();
                cp.SayHello();

                Console.WriteLine("获取  EnglishPeople （ English 定义在 EnglishPeople 类中 ）！");
                EnglishPeople ep = kernel.Get<EnglishPeople>();
                ep.SayHello();

                Console.WriteLine("直接获取名称为 Chinese 的 IHelloWorld");
                IHelloWorld ic = kernel.Get<IHelloWorld>("Chinese");
                Console.WriteLine(ic.HelloWorld());

                Console.WriteLine("直接获取名称为 English 的 IHelloWorld");
                IHelloWorld ie = kernel.Get<IHelloWorld>("English");
                Console.WriteLine(ie.HelloWorld());
            }




            Console.WriteLine("通过 标签的条件绑定方式， 获取指定的实例!");
            using (IKernel kernel = new StandardKernel(new MyModulesByConstraints()))
            {
                Console.WriteLine("获取标签中包含 EnglishKnowAble 的 HkPeople！");
                HkPeople cp = kernel.Get<HkPeople>();
                cp.SayHello();


                Console.WriteLine("获取标签中包含 EnglishKnowAble 的 JpPeople！");
                JpPeople jp = kernel.Get<JpPeople>();
                jp.SayHello();


                Console.WriteLine("获取标签中包含 ChineseKnowAble 的 TwPeople！");
                TwPeople ep = kernel.Get<TwPeople>();
                ep.SayHello();

            }

            Console.ReadLine();


        }
    }
}
