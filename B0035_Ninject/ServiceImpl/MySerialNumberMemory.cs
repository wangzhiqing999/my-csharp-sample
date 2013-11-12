using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using B0035_Ninject.Service;


namespace B0035_Ninject.ServiceImpl
{

    /// <summary>
    /// 流水号处理服务 的内存实现
    /// </summary>
    public class MySerialNumberMemory : IMySerialNumber
    {

        /// <summary>
        /// 流水序号的初始数值.
        /// </summary>
        private int number = 0;



        string IMySerialNumber.MySerialNumberCurrVal()
        {
            return string.Format("{0}{1}",
                DateTime.Today.ToString("yyyyMMdd"),
                number.ToString("0000"));
        }



        string IMySerialNumber.MySerialNumberNextVal()
        {
            number++;

            return string.Format("{0}{1}",
                DateTime.Today.ToString("yyyyMMdd"),
                number.ToString("0000"));
        }



    }


}
