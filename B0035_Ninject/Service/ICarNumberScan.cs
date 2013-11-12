using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0035_Ninject.Service
{
    
    /// <summary>
    /// 车牌号扫描接口.
    /// </summary>
    public interface ICarNumberScan
    {

        /// <summary>
        /// 获取扫描到的 车牌号码.
        /// </summary>
        /// <returns></returns>
        string GetCarNumber();


    }

}
