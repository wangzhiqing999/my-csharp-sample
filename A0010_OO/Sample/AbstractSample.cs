using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.Sample
{

    /// <summary>
    /// 测试 抽象类例子.
    /// </summary>
    public abstract class AbstractSample : ISample
    {

        protected String week;

        /// <summary>
        /// 实现接口中定义的属性.
        /// </summary>
        public String Week
        {
            get
            {
                return week;
            }
            set
            {
                week = value;
            }
        }



        /// <summary>
        /// 实现接口定义的 SayHello 方法.
        /// </summary>
        public void SayHello(String name)
        {
            SayBegin();
            Console.WriteLine(name);
            SayEnd();
            SayBye();
        }



        /// <summary>
        /// 定义一个 abstract 方法 非抽象子类必须实现.
        /// </summary>
        public abstract void SayBegin();


        /// <summary>
        /// 定义一个 virtual 方法 子类 可选择性实现.
        /// </summary>
        public virtual void SayEnd()
        {
            // 注意：
            // 在 C# 中，只有定义了 virtual 关键字的方法
            // 才允许被子类所 override 覆盖掉
        }


        /// <summary>
        /// 定义一个方法 子类 无法 覆盖。.
        /// </summary>
        public void SayBye()
        {
            Console.WriteLine("Bye!");
        }

    }

}
