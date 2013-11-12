using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Ninject.Modules;


using B0030_Ninject.Sample;
using B0032_Ninject.Sample;


namespace B0032_Ninject
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
    /// 本例子代码， 是为 测试 Ninject 中的  Object Scopes
    /// 
    /// 
    /// 
    /// </summary>
    public class MyModulesInSingletonScope : NinjectModule
    {



        public override void Load()
        {


            // ## To 方法：绑定到接口的具体实现。
            Bind<IHelloWorld>().To<HelloWorldScopes>().InSingletonScope();

          

        }


    }


}
