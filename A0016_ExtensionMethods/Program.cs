using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//  A0016_ExtensionMethods.Sample 命名空间下的类。 为 模拟 不是我们自己创建的类 或 我们不能直接修改的类.
using A0016_ExtensionMethods.Sample;

// A0016_ExtensionMethods.Extension  命名空间下的类。 为自己 为哪些不能修改的类，额外追加的方法。
using A0016_ExtensionMethods.Extension;

namespace A0016_ExtensionMethods
{
    /// <summary>
    /// 本例子
    /// 用于演示 扩展方法
    /// 扩展方法给我们提供了一种很便捷的方式，
	/// 通过这种方式我可以给那些不是我们自己创建的类(如第三方组件里面的)
	///	或是我们不能直接修改的类添加方法。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ShoppingCart cart = new ShoppingCart
            {
                Products = new List<Product> 
            {
                new Product {Name = "可口可乐", Price = 2, Count = 2, Category="饮料"},
                new Product {Name = "百事可乐", Price = 2, Count = 2, Category="饮料"},
                new Product {Name = "乐事薯片", Price = 7, Count = 1, Category="膨化食品"},
                new Product {Name = "奥利奥饼干", Price = 8, Count = 1, Category="饼干"}
            }
            };

            // 输出 购物车 信息.
            cart.PrintShoppingCart();

            // 输出总价.
            decimal cartTotal = cart.TotalPrices();
            Console.WriteLine("总金额: {0:c}", cartTotal);

            
            // 输出 饮料的 折扣.
            decimal disCount = cart.GetDiscount("饮料", -0.2M);
            Console.WriteLine("折扣: {0:c}", disCount);

            Console.ReadLine();
        }
    }
}
