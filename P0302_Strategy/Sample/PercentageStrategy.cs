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
    /// 本类是  按总金额， 按百分比做折扣 的 实现.
    /// </summary>
    public class PercentageStrategy : IDiscountStrategy
    {

        /// <summary>
        /// 折扣的百分比.
        /// </summary>
        public decimal Percent { set; get; }



        public decimal GetBookDiscount(decimal bookPrice, int bookCopies)
        {
            return bookPrice * bookCopies * Percent;
        }
    }

}
