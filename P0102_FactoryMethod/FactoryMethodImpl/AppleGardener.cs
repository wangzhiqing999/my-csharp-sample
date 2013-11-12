using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;
using P0101_SimpleFactory.ServiceImpl;
using P0102_FactoryMethod.FactoryMethod;

namespace P0102_FactoryMethod.FactoryMethodImpl
{
    /// <summary>
    /// 具体工厂. 
    /// 苹果
    /// </summary>
    public class AppleGardener : IFruitGardener
    {
        IFruit IFruitGardener.Factory()
        {
            Console.WriteLine("通过苹果工厂，创建一个苹果！");
            return new Apple();
        }
    }
}
