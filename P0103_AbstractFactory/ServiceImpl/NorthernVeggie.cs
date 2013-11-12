using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.Service;

namespace P0103_AbstractFactory.ServiceImpl
{
    /// <summary>
    /// 北方生产的蔬菜.
    /// </summary>
    class NorthernVeggie : IVeggie
    {

        void IVeggie.Plant()
        {
            Console.WriteLine("在气温比较低的区域，种植下了北方蔬菜！");
        }
    }
}
