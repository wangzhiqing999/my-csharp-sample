using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A002_OO.CardSample
{


    /// <summary>
    /// 卡
    /// 
    /// 用举例的方法来 演示 override 与 new 的区别.
    /// 
    /// 基类： 卡
    /// 有2个方法
    /// 一个是 virtual 的 取款 的方法。
    /// 一个是 普通的 排队 的方法。
    /// 
    /// 子类：普通卡.
    /// override 掉 取款 的方法。
    /// 
    /// 子类：金卡.
    /// override 掉 取款 的方法。
    /// new 掉  排队 的方法。
    /// 
    /// 
    /// 当 金卡 c = new 金卡的时候
    /// c.取款， 将执行 金卡 里面定义的 取款方法.
    /// c.排队， 将执行 金卡 里面定义的 排队方法.
    /// 
    /// 当 卡 c = new 金卡的时候
    /// c.取款， 将执行 金卡 里面定义的 取款方法.
    /// c.排队， 将执行 卡 里面定义的 排队方法.
    /// 
    /// 
    /// </summary>
    class Card
    {

        /// <summary>
        /// 取钱.
        /// </summary>
        public virtual void TakeMoney()
        {
            Console.WriteLine("从当前帐户取钱！");
        }


        /// <summary>
        /// 排队.
        /// </summary>
        public void LineUp()
        {
            Console.WriteLine("一个一个正常排队！");
        }


    }
}
