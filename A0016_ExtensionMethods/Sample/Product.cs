using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0016_ExtensionMethods.Sample
{

    /// <summary>
    /// 商品.
    /// 本类为 模拟 第三方提供的，我们不能直接修改的类。
    /// </summary>
    public class Product
    {
        /// <summary>
        /// 商品ID.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// 商品名.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 价格.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 数量.
        /// </summary>
        public int Count { set; get; }

        /// <summary>
        /// 分类.
        /// </summary>
        public string Category { set; get; }
    }

}
