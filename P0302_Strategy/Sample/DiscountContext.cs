using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0302_Strategy.Sample
{
    /// <summary>
    ///  策略模式 中的 环境对象(Context)
    ///  
    /// 该类中实现了对抽象策略中定义的接口或者抽象类的引用。 
    /// 
    /// 
    /// 
    /// </summary>
    public class DiscountContext
    {

        /// <summary>
        /// 抽象策略对象(Strategy) 的引用.
        /// </summary>
        private IDiscountStrategy strategy;



        public DiscountContext(IDiscountStrategy strategy)
        {
            this.strategy = strategy;
        }



        public decimal GetBookDiscount(decimal bookPrice, int bookCopies)
        {
            return strategy.GetBookDiscount(bookPrice, bookCopies);
        }

    }

}
