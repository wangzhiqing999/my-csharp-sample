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
    /// “热带系列”的 具体工厂类.
    /// </summary>
    public class TropicalGardener : IGardener
    {
        /// <summary>
        /// 获取一个 水果.
        /// </summary>
        /// <returns></returns>
        IFruit IGardener.CreateFruit()
        {
            // 返回 热带的 水果.
            return new TropicalFruit();
        }


        /// <summary>
        /// 获取一个 蔬菜.
        /// </summary>
        /// <returns></returns>
        IVeggie IGardener.CreateVeggie()
        {
            // 返回 热带的 蔬菜.
            return new TropicalVeggie();
        }
    }
}
