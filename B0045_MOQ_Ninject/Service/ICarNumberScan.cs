using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0045_MOQ_Ninject.Service
{
    /// <summary>
    /// 车牌号扫描接口.
    /// 该接口定义了一个 获取车牌号码 的方法.
    /// </summary>
    public interface ICarNumberScan
    {
        /// <summary>
        /// 获取扫描到的 车牌号码.
        /// </summary>
        /// <returns>通过硬件识别到的 车牌号码</returns>
        string GetCarNumber();
    }
}
