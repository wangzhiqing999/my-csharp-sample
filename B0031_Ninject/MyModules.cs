using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Ninject.Modules;


using B0030_Ninject.Sample;
using B0031_Ninject.Sample;


namespace B0031_Ninject
{


    /// <summary>
    /// 注册的接口和接口实现类.
    /// 
    /// 
    /// NinjectModule
    /// 是通过在 Load() 方法中。
    /// 
    /// 指定 接口的具体实现.
    /// 
    /// 
    /// 
    /// 本例子代码， 是为 IHelloWorld 注入多个 实现。
    /// 
    /// 目标使用类的属性，是一个 IEnumerable 的数据类型.
    /// 
    /// 
    /// 参考
    /// 
    /// 
    /// 
    /// </summary>
    public class MyModules : NinjectModule
    {



        public override void Load()
        {


            // ## To 方法：绑定到接口的具体实现。
            Bind<IHelloWorld>().To<HelloWorldChinese>();



            // ## ToConstant 方法：绑定一个常量.
            Bind<IHelloWorld>().ToConstant(new HelloWorldEnglish());



            // ### ToMethod 方法：绑定到方法。
            Bind<IHelloWorld>().ToMethod(context => HelloWorldSingleton.Instance());


            // ### ToProvider  :  使用自己定义的 “工厂类”来提供.
            Bind<IHelloWorld>().ToProvider(new HelloWorldProvider());

        }


    }


}
