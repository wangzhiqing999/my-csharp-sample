using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;

namespace P0101_SimpleFactory.ServiceImpl
{
    /// <summary>
    /// 草莓类
    /// 实现水果接口.
    /// </summary>
    public class Strawberry : IFruit
    {
        #region 实现接口代码.

        /// <summary>
        /// 种植.
        /// </summary>
        void IFruit.Plant()
        {
            Console.WriteLine("我种下了一颗草莓！");
        }

        /// <summary>
        /// 生长.
        /// </summary>
        void IFruit.Grow()
        {
            Console.WriteLine("草莓不断地长大！");
        }

        /// <summary>
        /// 收获.
        /// </summary>
        void IFruit.Harvest()
        {
            Console.WriteLine("草莓成熟啦，收草莓咯～～～");
        }

        #endregion
 


    }
}
