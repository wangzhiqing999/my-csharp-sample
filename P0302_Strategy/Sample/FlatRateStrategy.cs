using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0302_Strategy.Sample
{


    /// <summary>
    /// 策略模式 中的 具体策略对象(ConcreteStrategy)
    /// 它封装了实现同不功能的不同算法。 
    /// 
    /// 本类是  按数量，每本书折扣 一定金额 的 实现.
    /// </summary>
    public class FlatRateStrategy : IDiscountStrategy
    {

        /// <summary>
        /// 每一本书 给的折扣
        /// </summary>
        public decimal OneCopyDiscount { set; get; }


        public decimal GetBookDiscount(decimal bookPrice, int bookCopies)
        {
            return bookCopies * OneCopyDiscount;
        }

    }
}
