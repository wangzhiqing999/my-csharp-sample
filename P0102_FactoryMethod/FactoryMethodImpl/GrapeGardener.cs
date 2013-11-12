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
    /// 葡萄
    /// </summary>
    public class GrapeGardener: IFruitGardener
    {
        IFruit IFruitGardener.Factory()
        {
            Console.WriteLine("通过葡萄工厂，创建一个葡萄！");
            return new Grape();
        }
    }
}
