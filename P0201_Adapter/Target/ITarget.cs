using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0201_Adapter.Target
{
    /// <summary>
    /// 这个类是 “适配器”模式中的 目标（Target）角色
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// 此方法用于 模拟一个  源（Adaptee） 类已经有的方法。
        /// </summary>
        void SayHelloworld();

        /// <summary>
        /// 此方法用于 模拟一个  源（Adaptee） 类 没有的方法。
        /// 
        /// 也就是  适配器（Adapter）角色  需要 适配 的方法.
        /// </summary>
        void SayGoodbye();

    }
}
