using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0201_Adapter.Adaptee;
using P0201_Adapter.Target;

namespace P0201_Adapter.Adapter
{

    /// <summary>
    /// 这个类是 “适配器”模式中的 适配器（Adapter）角色
    /// 
    /// 
    /// 本适配器器是“类的适配器”
    /// 是通过  继承  源  
    ///         实现  目标接口
    /// 来实现的。
    /// 
    /// 对于“源” 实现了 部分 “目标接口” 的情况下。 使用这种方式，还是比较省事的。
    /// 
    /// 如果“源” 与 “目标接口” 完全不搭界，甚至还会产生冲突的话。
    /// 那么使用 “对象的适配器” 方式来处理。
    /// </summary>
    public class ClassAdapter : OldServiceImpl, ITarget
    {

        /// <summary>
        /// 对于 源 类中， 没有的方法。
        /// 适配器 对其进行补充的处理。
        /// </summary>
        public void SayGoodbye()
        {
            Console.WriteLine("适配器中追加的实现！Goodbye！");
        }
    }


}
