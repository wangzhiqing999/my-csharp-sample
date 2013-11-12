using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;


using B0030_Ninject.Sample;



namespace B0033_Ninject
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
    /// </summary>
    public class MyModulesByName : NinjectModule
    {


        public override void Load()
        {

            // 指定 IHelloWorld  接口的实现 为 HelloWorldChinese    
            // 并命名为  Chinese
            Bind<IHelloWorld>().To<HelloWorldChinese>().Named("Chinese");



            // 指定 IHelloWorld  接口的实现 为 HelloWorldEnglish    
            // 并命名为  English
            Bind<IHelloWorld>().To<HelloWorldEnglish>().Named("English");


        }


    }


}
