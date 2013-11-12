using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Activation;

using B0030_Ninject.Sample;


namespace B0031_Ninject.Sample
{


    /// <summary>
    /// 
    /// 本类用于  用户自定义的 实例创建处理.
    /// 
    /// 
    /// https://github.com/ninject/ninject/wiki/Providers%2C-Factory-Methods-and-the-Activation-Context
    /// </summary>
    public class HelloWorldProvider : Provider<IHelloWorld>
    {


        protected override IHelloWorld CreateInstance(IContext context)
        {

            HelloWorldSingleton result = HelloWorldSingleton.Instance();

            result.Keyword = "本实例由 HelloWorldProvider 创建！";

            return result;
        }


    }
}
