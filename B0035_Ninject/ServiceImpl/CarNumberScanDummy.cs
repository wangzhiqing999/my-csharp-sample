using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using B0035_Ninject.Service;


namespace B0035_Ninject.ServiceImpl
{


    /// <summary>
    /// 车牌号扫描接口 的虚拟实现.
    /// </summary>
    class CarNumberScanDummy : ICarNumberScan
    {

        #region 实现单例的代码.


        /// <summary>
        /// 私有构造函数.
        /// 不允许外部实例化.
        /// </summary>
        private CarNumberScanDummy()
        {
        }

        /// <summary>
        /// 内部私有静态实例.
        /// </summary>
        private static CarNumberScanDummy me;


        /// <summary>
        /// 外部获取单例的代码.
        /// </summary>
        /// <returns></returns>
        public static CarNumberScanDummy Instance()
        {
            if (me == null)
            {
                me = new CarNumberScanDummy();
            }

            return me;
        }


        #endregion




        string ICarNumberScan.GetCarNumber()
        {
            return "沪AZZZZZZ";
        }
    }


}
