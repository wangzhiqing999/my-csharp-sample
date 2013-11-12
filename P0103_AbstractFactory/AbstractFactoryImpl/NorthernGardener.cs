using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.AbstractFactory;
using P0103_AbstractFactory.Service;
using P0103_AbstractFactory.ServiceImpl;

namespace P0103_AbstractFactory.AbstractFactoryImpl
{

    /// <summary>
    /// “北方系列”的 具体工厂类.
    /// </summary>
    public class NorthernGardener : IGardener
    {
        /// <summary>
        /// 获取一个 水果.
        /// </summary>
        /// <returns></returns>
        IFruit IGardener.CreateFruit()
        {
            // 返回 北方的 水果.
            return new NorthernFruit();
        }

        /// <summary>
        /// 获取一个 蔬菜.
        /// </summary>
        /// <returns></returns>
        IVeggie IGardener.CreateVeggie()
        {
            // 返回 北方的 蔬菜.
            return new NorthernVeggie();
        }
    }
}
