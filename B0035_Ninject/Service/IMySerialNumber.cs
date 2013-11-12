using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0035_Ninject.Service
{



    /// <summary>
    /// 流水号处理接口.
    /// 
    /// 本接口用于 管理一个  YYYYMMDD0001 格式的流水号.
    /// 
    /// 例如：
    /// 201203300001
    /// 
    /// </summary>
    public interface IMySerialNumber
    {


        /// <summary>
        /// 获取 流水号的当前值.
        /// </summary>
        /// <returns></returns>
        string MySerialNumberCurrVal();



        /// <summary>
        /// 获取下一个流水号数值.
        /// </summary>
        /// <returns></returns>
        string MySerialNumberNextVal();


    }


}
