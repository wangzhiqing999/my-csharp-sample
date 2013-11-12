using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.Service;

namespace P0103_AbstractFactory.ServiceImpl
{

    /// <summary>
    /// 北方水果
    /// </summary>
    public class NorthernFruit : IFruit
    {

        void IFruit.Plant()
        {
            Console.WriteLine("在气温比较低的区域，种植下了北方水果！");
        }

        void IFruit.Grow()
        {
            Console.WriteLine("北方水果 不断生长！");
        }

        void IFruit.Harvest()
        {
            Console.WriteLine("北方水果 成熟了，收获中！");
        }
    }
}
