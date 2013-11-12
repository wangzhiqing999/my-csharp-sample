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
    /// 草莓
    /// </summary>
    public class StrawberryFruitGardener : IFruitGardener
    {
        IFruit IFruitGardener.Factory()
        {
            Console.WriteLine("通过草莓工厂，创建一个草莓！");
            return new Strawberry();
        }
    }
}
