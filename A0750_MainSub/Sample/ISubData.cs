using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0750_MainSub.Sample
{
    public interface ISubData
    {

        /// <summary>
        /// 子数据的代码.
        /// </summary>
        string SubDataCode { set; get; }



        /// <summary>
        /// 子数据的初始数值.
        /// </summary>
        decimal SubInitValue { set; get; }



        /// <summary>
        /// 子数据的余额.
        /// </summary>
        decimal SubBalanceValue { set; get; }



        /// <summary>
        /// 子数据的 已使用（已完成）的金额 = 初始值-余额.
        /// </summary>
        decimal SubFinishValue { get; }

    }
}
