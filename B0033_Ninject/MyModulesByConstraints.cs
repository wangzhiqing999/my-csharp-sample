using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Ninject.Modules;


using B0030_Ninject.Sample;
using B0033_Ninject.Sample;


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
    public class MyModulesByConstraints : NinjectModule
    {


        public override void Load()
        {

            // # 测试  WhenClassHas
            // 指定 IHelloWorld  接口的实现 为 HelloWorldChinese    
            // 仅仅当 类中有 ChineseKnowAble 标签的时候.
            Bind<IHelloWorld>().To<HelloWorldChinese>().WhenClassHas<ChineseKnowAble>();



            // # 测试 WhenMemberHas
            // 指定 IHelloWorld  接口的实现 为 HelloWorldEnglish    
            // 仅仅当 方法中有 EnglishKnowAble 标签的时候.
            Bind<IHelloWorld>().To<HelloWorldEnglish>().WhenMemberHas<EnglishKnowAble>();




            // # 测试 WhenTargetHas
            // 指定 IHelloWorld  接口的实现 为 HelloWorldEnglish    
            // 仅仅当  依赖注入的 定义前 中有 EnglishKnowAble 标签的时候.
            Bind<IHelloWorld>().To<HelloWorldEnglish>().WhenTargetHas<EnglishKnowAble>();
        }


    }


}
