using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace P0105_Multiton.Sample
{
    /// <summary>
    /// 多例的 例子代码
    /// 本例子用于 模拟 管理 2个实例的处理.
    /// </summary>
    public class Die
    {
        /// <summary>
        /// 内部静态 实例1.
        /// </summary>
        private static readonly Die die1 = new Die();

        /// <summary>
        /// 内部静态 实例2
        /// </summary>
        private static readonly Die die2 = new Die();


        /// <summary>
        /// 私有的构造函数.
        /// 必须的
        /// </summary>
        private Die()
        {
        }


        /// <summary>
        /// 获取 实例的静态方法.
        /// </summary>
        /// <param name="whichOne"></param>
        /// <returns></returns>
        public static Die GetInstance(int whichOne)
        {
            if (whichOne % 2 == 1)
            {
                return die1;
            }
            else
            {
                return die2;
            }
        }


        /// <summary>
        /// 获取一个 1-6的随机数.
        /// </summary>
        /// <returns></returns>
        public int Dice()
        {
            Thread.Sleep(1);

            // 构造随机数.
            Random r = new Random(DateTime.Now.Millisecond);
            // 获取随机数.
            int val = r.Next();
            // 返回 1-6 直接的结果.
            return (val % 6) + 1;
        }


    }
}
