using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.Service;

namespace P0103_AbstractFactory.AbstractFactory
{
    /// <summary>
    /// 抽象工厂.
    /// </summary>
    public interface IGardener
    {
        /// <summary>
        /// 获取一个 水果.
        /// </summary>
        /// <returns></returns>
        IFruit CreateFruit();

        /// <summary>
        /// 获取一个 蔬菜.
        /// </summary>
        /// <returns></returns>
        IVeggie CreateVeggie();
    }
}
