using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0101_SimpleFactory.Service
{
    /// <summary>
    /// 水果 接口.
    /// </summary>
    public interface IFruit
    {
        /// <summary>
        /// 种植.
        /// </summary>
        void Plant();

        /// <summary>
        /// 生长.
        /// </summary>
        void Grow();

        /// <summary>
        /// 收获.
        /// </summary>
        void Harvest();
    }
}
