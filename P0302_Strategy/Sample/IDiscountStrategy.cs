using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0302_Strategy.Sample
{

    /// <summary>
    /// 策略模式 中的 抽象策略对象(Strategy)
    /// 它可由接口或抽象类来实现。
    /// 
    /// 这里是一个  接口。 
    /// 用于计算 买书的 折扣.
    /// </summary>
    public interface IDiscountStrategy
    {

        /// <summary>
        /// 计算买书可以获得的折扣.
        /// </summary>
        /// <param name="bookPrice">书的单价</param>
        /// <param name="bookCopies">书的数量</param>
        /// <returns></returns>
        decimal GetBookDiscount(decimal bookPrice, int bookCopies);

    }
}
