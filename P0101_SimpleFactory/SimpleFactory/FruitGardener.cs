using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;
using P0101_SimpleFactory.ServiceImpl;

namespace P0101_SimpleFactory.SimpleFactory
{
    /// <summary>
    /// 农场园丁.
    /// </summary>
    public class FruitGardener
    {
        /// <summary>
        /// 静态工厂方法.
        /// 用于获取水果的实例.
        /// </summary>
        /// <param name="name">水果的名称</param>
        /// <returns>水果的实例</returns>
        public static IFruit Factory(string name)
        {
            if ("Apple".Equals(name, StringComparison.CurrentCultureIgnoreCase))
            {
                // 返回 苹果 实例.
                return new Apple();
            }
            else if ("Grape".Equals(name, StringComparison.CurrentCultureIgnoreCase))
            {
                // 返回 葡萄 实例.
                return new Grape();
            }
            else if ("Strawberry".Equals(name, StringComparison.CurrentCultureIgnoreCase))
            {
                // 返回 草莓 实例.
                return new Strawberry();
            }
            else
            {
                // 无法识别的水果类型.
                throw new ArgumentException("无法识别的水果！");
            }
        }
    }
}
