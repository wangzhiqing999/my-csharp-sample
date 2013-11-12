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
    public class Invite : DefaultAdapter
    {
        /// <summary>
        /// 技术部 面试.
        /// </summary>
        public override void Test2()
        {
            Console.WriteLine("对于内部邀请的，技术部还是要谈谈的......");
        }

        /// <summary>
        ///  HR  面试.
        /// </summary>
        public override void Test3()
        {
            Console.WriteLine("对于内部邀请的，HR 也是不可避免的......");
        }

        /// <summary>
        ///  BOSS 面试.
        /// </summary>
        public override void Test5()
        {
            Console.WriteLine("老板的兄弟都要和老板谈了，何况是普通的邀请？");
        }

    }
}
