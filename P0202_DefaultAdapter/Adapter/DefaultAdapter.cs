using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0202_DefaultAdapter.Target;

namespace P0202_DefaultAdapter.Adapter
{

    /// <summary>
    /// 这个类是 “缺省适配” 模式中的  缺省适配
    /// 
    /// 这个类为接口中每个方法提供一个默认实现（空方法）。
    /// 
    /// 这个类 被定义为 抽象。（因为实例化这个类没有意义）
    /// 
    /// 
    /// </summary>
    public abstract class DefaultAdapter : ITarget
    {

        /// <summary>
        /// 电话面试
        /// 注意， 空方法定义的时候， 加上 virtual 标记.
        /// </summary>
        public virtual void Test1()
        {
        }

        /// <summary>
        /// 技术部 面试.
        /// </summary>
        public virtual void Test2()
        {
        }

        /// <summary>
        /// HR 面试
        /// </summary>
        public virtual void Test3()
        {
        }

        /// <summary>
        /// 笔试
        /// </summary>
        public virtual void Test4()
        {
        }

        /// <summary>
        /// BOSS 面试.
        /// </summary>
        public virtual void Test5()
        {
        }
    }
}
