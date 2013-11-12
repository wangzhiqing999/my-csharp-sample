using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0202_DefaultAdapter.Adapter
{
    /// <summary>
    /// 这个类是 “缺省适配” 模式中的  不需要全部实现适配器接口提供的方法的  类.
    /// 
    /// </summary>
    public class BossBother : DefaultAdapter
    {

        /// <summary>
        /// 只实现 一个方法.
        /// 
        /// 其他方法不需要实现了.
        /// </summary>
        public override void Test5()
        {
            Console.WriteLine("对于老板的兄弟，直接和老板谈谈就好了......");
        }

    }
}
