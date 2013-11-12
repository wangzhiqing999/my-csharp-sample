using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using P0101_SimpleFactory.Service;

namespace P0101_SimpleFactory.ServiceImpl
{
    /// <summary>
    /// 苹果类
    /// 实现水果接口.
    /// </summary>
    public class Apple : IFruit
    {

        #region 实现接口代码.

        /// <summary>
        /// 种植.
        /// </summary>
        void IFruit.Plant()
        {
            Console.WriteLine("我种下了一颗苹果树！");
        }

        /// <summary>
        /// 生长.
        /// </summary>
        void IFruit.Grow()
        {
            Console.WriteLine("苹果树不断地长大！");
        }

        /// <summary>
        /// 收获.
        /// </summary>
        void IFruit.Harvest()
        {
            Console.WriteLine("收苹果咯～～～");
        }

        #endregion


        #region 本类特有的实现.

        /// <summary>
        /// 苹果树的 年龄
        /// </summary>
        public int TreeAge { set; get; }

        #endregion


    }
}
