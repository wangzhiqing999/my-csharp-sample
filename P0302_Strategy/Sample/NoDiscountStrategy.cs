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
    /// 本类是  无折扣的 实现.
    /// </summary>
    class NoDiscountStrategy : IDiscountStrategy
    {

        public decimal GetBookDiscount(decimal bookPrice, int bookCopies)
        {
            // 无折扣.
            return 0;
        }

    }

}
