using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;

namespace P0102_FactoryMethod.FactoryMethod
{
    /// <summary>
    /// 工厂方法 模式中的 抽象工厂.
    /// </summary>
    public interface IFruitGardener
    {
        /// <summary>
        /// 工厂方法.
        /// 获取一种水果.
        /// </summary>
        /// <returns></returns>
        IFruit Factory();
    }
}
