using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B0035_Ninject.Service
{


    /// <summary>
    /// 收银机接口.
    /// </summary>
    public interface IPosService
    {

        /// <summary>
        /// 销售
        /// </summary>
        /// <param name="money"> 金额 </param>
        void DoSale(int money);


    }


}
