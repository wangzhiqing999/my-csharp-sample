using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;


using Ninject;

using B0035_Ninject.Service;


namespace B0035_Ninject.ServiceImpl
{

    /// <summary>
    /// 收银机的虚拟实现.
    /// </summary>
    public class PosDummy : IPosService
    {


        #region 依赖注入的部分.


        /// <summary>
        /// 流水号服务.
        /// </summary>
        private IMySerialNumber mySn = null;

        /// <summary>
        /// 流水号服务的属性.
        /// </summary>
        [Inject]
        public IMySerialNumber MySerialNumber
        {
            set
            {
                mySn = value;
            }
        }


        #endregion




        void IPosService.DoSale(int money)
        {
            Debug.Assert(money > 0, "收银不应收到负数的金额！");

            // 获取一个新的流水号.
            string sn = mySn.MySerialNumberNextVal();

            Console.WriteLine(
                "流水号{0}   金额{1}",
                sn,
                money);
        }


    }

}
