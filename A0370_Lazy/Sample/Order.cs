using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0370_Lazy.Sample
{

    /// <summary>
    /// 用于测试的 客户订单类.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// 订单编号.
        /// </summary>
        public long OrderID { set; get; }


        /// <summary>
        /// 商品代码.
        /// </summary>
        public long ItemCode { set; get; }


        /// <summary>
        /// 商品名称.
        /// </summary>
        public string ItemName { set; get; }


        /// <summary>
        /// 商品数量.
        /// </summary>
        public int ItemCount { set; get; }


        // 这个主要是 测试 Lazy 的， 就不加太多属性了......


        public override string ToString()
        {
            return String.Format("[{0}] {1} ( {2} ): {3}", OrderID, ItemCode, ItemName, ItemCount);
        }

    }

}
