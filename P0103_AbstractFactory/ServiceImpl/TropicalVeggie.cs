using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0103_AbstractFactory.Service;

namespace P0103_AbstractFactory.ServiceImpl
{
    /// <summary>
    /// 热带的蔬菜.
    /// </summary>
    class TropicalVeggie : IVeggie
    {

        void IVeggie.Plant()
        {
            Console.WriteLine("在气温比较高的热带区域，种植下了热带蔬菜！");
        }
    }
}
