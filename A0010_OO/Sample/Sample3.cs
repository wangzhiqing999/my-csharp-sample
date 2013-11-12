using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.Sample
{
    class Sample3 : AbstractSample
    {
        public override void SayBegin()
        {
            Console.WriteLine("摩西摩西!");
        }



        /// <summary>
        /// Sample3 与 Sample2 的区别
        /// 
        /// Sample2 是 override 了 SayEnd() 方法.
        /// Sample3 是 new 了 SayEnd() 方法.
        /// 
        /// 使用 new 关键字，只有在 Sample3 sample3 = new Sample3() 的时候。
        /// 
        /// 显式的、直接的调用SayEnd()方法时，才会被调用。
        /// 
        /// 如果这个方法，是父类 的另外一个方法，间接调用的，那么使用 new 关键字
        /// 无法使这个方法被 父类的方法所使用。
        /// 
        /// </summary>
        public new void SayEnd()
        {
            Console.WriteLine("Test New Keyword!");
        }
    }
}
