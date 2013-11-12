using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0016_ExtensionMethods.Sample
{
    /// <summary>
    /// 购物车.
    /// 本类为 模拟 第三方提供的，我们不能直接修改的类。
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// 已选择的商品列表.
        /// </summary>
        public List<Product> Products { get; set; }
    }

}
