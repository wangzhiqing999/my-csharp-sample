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
    /// 本适配器器是“对象的适配器”
    /// 
    /// 本适配器器 仅仅实现 目标接口
    /// 源 仅仅是本类中的一个对象。
    /// 
    /// 
    /// </summary>
    public class ObjectAdapter : ITarget
    {

        /// <summary>
        /// 源   对象.
        /// </summary>
        private OldServiceImpl oldImpl = new OldServiceImpl();


        /// <summary>
        /// 这个方法 源  有的.
        /// </summary>
        public void SayHelloworld()
        {
            // 这里直接调用
            // 也可以做相应扩展.
            oldImpl.SayHelloworld();
            Console.WriteLine("对象适配器额外追加 Helloworld！");
        }


        /// <summary>
        /// 对于 源 类中， 没有的方法。
        /// 适配器 对其进行补充的处理。
        /// </summary>
        public void SayGoodbye()
        {
            Console.WriteLine("对象适配器中追加的实现！Goodbye！");
        }


    }


}
