using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0045_MOQ_Ninject.Service
{
    /// <summary>
    /// 停车场处理接口.
    /// 本接口用于定义 停车场收费记录的方法.
    /// </summary>
    public interface ICarPark
    {
        /// <summary>
        /// 车子进入 停车场.
        /// </summary>
        /// <param name="cardNum">进入车库的 车牌号码</param>
        void InCarPark(string cardNum);

        /// <summary>
        /// 车子离开 停车场
        /// </summary>
        /// <param name="cardNum">离开车库的 车牌号码</param>
        void OutCarPark(string cardNum);
    }
}
