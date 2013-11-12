using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0202_DefaultAdapter.Adapter
{
    public class Normal : DefaultAdapter
    {

        /// <summary>
        /// 电话面试.
        /// </summary>
        public override void Test1()
        {
            Console.WriteLine("对于普通的嘛，先电话面试，排除掉部分......");
        }


        /// <summary>
        /// 技术部 面试.
        /// </summary>
        public override void Test2()
        {
            Console.WriteLine("对于普通的，技术部面试，排除掉部分......");
        }

        /// <summary>
        ///  HR  面试.
        /// </summary>
        public override void Test3()
        {
            Console.WriteLine("对于普通的，HR 排除掉部分......");
        }


        /// <summary>
        ///  笔试
        /// </summary>
        public override void Test4()
        {
            Console.WriteLine("对于普通的，笔试是不可避免的......");
        }

        /// <summary>
        ///  BOSS 面试.
        /// </summary>
        public override void Test5()
        {
            Console.WriteLine("对于普通的，老板看的顺眼是必须的......");
        }
    }
}
