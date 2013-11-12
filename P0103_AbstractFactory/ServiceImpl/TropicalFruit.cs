using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.Service;

namespace P0103_AbstractFactory.ServiceImpl
{

    /// <summary>
    /// 热带水果。
    /// </summary>
    public class TropicalFruit : IFruit
    {

        void IFruit.Plant()
        {
            Console.WriteLine("在气温比较高的热带区域，种植下了热带水果！");
        }

        void IFruit.Grow()
        {
            Console.WriteLine("热带水果 不断生长！");
        }

        void IFruit.Harvest()
        {
            Console.WriteLine("热带水果 成熟了，收获中！");
        }
    }
}
