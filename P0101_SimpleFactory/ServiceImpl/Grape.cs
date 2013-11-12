using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;

namespace P0101_SimpleFactory.ServiceImpl
{
    /// <summary>
    /// 葡萄类
    /// 实现水果接口.
    /// </summary>
    public class Grape : IFruit
    {
        #region 实现接口代码.

        /// <summary>
        /// 种植.
        /// </summary>
        void IFruit.Plant()
        {
            Console.WriteLine("我种下了一颗葡萄！");
        }

        /// <summary>
        /// 生长.
        /// </summary>
        void IFruit.Grow()
        {
            Console.WriteLine("葡萄不断地长大！");
        }

        /// <summary>
        /// 收获.
        /// </summary>
        void IFruit.Harvest()
        {
            Console.WriteLine("葡萄成熟啦，收葡萄咯～～～");
        }

        #endregion


        #region 本类特有的实现.

        /// <summary>
        /// 本葡萄有没有籽.
        /// </summary>
        public bool IsSeedLess { set; get; }

        #endregion
    }
}
