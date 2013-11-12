using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.Sample
{
    class Sample2 : AbstractSample
    {
        public override void SayBegin()
        {
            Console.WriteLine("Hello!");
        }

        /// <summary>
        /// Sample2 与 Sample1 的区别
        /// 
        /// Sample1 未定义 SayEnd() 的方法， 调用过程，将使用父类的代码
        /// Sample2 override 了SayEnd() 的方法， 调用过程，将使用当前类的代码
        /// </summary>
        public override void SayEnd()
        {
            Console.WriteLine("Nice to meet you!");
        }
    }
}
