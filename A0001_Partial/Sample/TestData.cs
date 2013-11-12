using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0001_Partial.Sample
{
    
    
    /// <summary>
    /// 本例子用于演示 partial 关键字的使用.
    /// 
    /// c#2.0引入了局部类型的概念。局部类型允许我们将一个类、接口或结构分成好几个部分，分别实现在几个不同的.cs文件中。 　　
    /// 局部类型适用于以下情况： 　　
    /// （1）类型特别大，不宜放在一个文件中实现。 　　
    /// （2）一个类型中的一部分代码为自动化工具生成的代码，不宜与我们自己编写的代码混合在一起。 　　
    /// （3）需要多人合作编写一个类。
    /// 
    /// 
    /// 局部类型的限制
    /// （1）局部类型只适用于类、接口、结构，不支持委托和枚举。 　　
    /// （2）同一个类型的各个部分必须都有修饰符partial。 　　
    /// （3）使用局部类型时，一个类型的各个部分必须位于相同的命名空间中。 　　
    /// （4）一个类型的各个部分必须同时编译。
    /// 
    /// </summary>
    public partial class Test
    {

        // 本例子用于 模拟 
        // 一个类型中的一部分代码为自动化工具生成的代码
        // 另外一个文件为 自己写的代码.


        /// <summary>
        /// 用户名.
        /// </summary>
        public string UserName { set; get; }


        /// <summary>
        /// 密码.
        /// </summary>
        public string Passwrod { set; get; }


    }



}
