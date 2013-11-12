using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0202_DefaultAdapter.Target
{
    /// <summary>
    /// 这个类是 “缺省适配” 模式中的  定义了很多方法的 接口.
    /// </summary>
    public interface ITarget
    {

        /// <summary>
        /// 电话面试
        /// </summary>
        void Test1();

        /// <summary>
        /// 技术部 面试.
        /// </summary>
        void Test2();

        /// <summary>
        /// HR 面试
        /// </summary>
        void Test3();

        /// <summary>
        /// 笔试
        /// </summary>
        void Test4();

        /// <summary>
        /// BOSS 面试.
        /// </summary>
        void Test5();


    }

}
