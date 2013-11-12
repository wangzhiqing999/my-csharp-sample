using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0016_ExtensionMethods.Sample;

namespace A0016_ExtensionMethods.Extension
{

    /// <summary>
    /// 本类为，我们为那些 “不能直接修改的类”
    /// 额外追加的方法。
    /// </summary>
    public static class MyExtensionMethods
    {
        /// <summary>
        /// 输出 购物车 信息.
        /// 本方法，为 ShoppingCart 类。 扩展追加一个 PrintShoppingCart 的方法。
        /// </summary>
        /// <param name="cartParam"></param>
        public static void PrintShoppingCart(this ShoppingCart cartParam)
        {
            foreach (Product prod in cartParam.Products)
            {
                Console.WriteLine("物品：{0}；单价：{1:c}；数量：{2}", prod.Name, prod.Price, prod.Count);
            }
        }

        /// <summary>
        /// 获取购物车 合计价格.
        /// 本方法，为 ShoppingCart 类。 扩展追加一个 TotalPrices 的方法。
        /// </summary>
        /// <param name="cartParam"></param>
        /// <returns></returns>
        public static decimal TotalPrices(this ShoppingCart cartParam)
        {
            decimal total = 0;
            foreach (Product prod in cartParam.Products)
            {
                total += prod.Price * prod.Count;
            }
            return total;
        }


        /// <summary>
        /// 获取折扣信息.
        /// 本方法，为 ShoppingCart 类。 扩展追加一个 GetDiscount ( 分类， 折扣比率 ) 的方法。
        /// </summary>
        /// <param name="cartParam"></param>
        /// <param name="category"></param>
        /// <param name="dis"></param>
        /// <returns></returns>
        public static decimal GetDiscount(this ShoppingCart cartParam, string category, decimal dis)
        {
            decimal totalDiscount = 0;
            foreach (Product prod in cartParam.Products.Where(p=>p.Category ==category) )
            {
                totalDiscount += prod.Price * prod.Count * dis;
            }
            return totalDiscount;
        }
    }
}
