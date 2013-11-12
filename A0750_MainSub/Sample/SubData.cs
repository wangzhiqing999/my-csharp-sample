using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0750_MainSub.Sample
{
    
    
    /// <summary>
    /// 子数据
    /// （分割后的虚拟数据）
    /// </summary>
    public class SubData : ISubData
    {

        /// <summary>
        /// 子数据的代码.
        /// </summary>
        public virtual string SubDataCode { set; get; }



        /// <summary>
        /// 子数据的初始数值.
        /// </summary>
        public virtual decimal SubInitValue { set; get; }



        /// <summary>
        /// 子数据的余额.
        /// </summary>
        public virtual decimal SubBalanceValue { set; get; }



        /// <summary>
        /// 子数据的 已使用（已完成）的金额 = 初始值-余额.
        /// </summary>
        public virtual decimal SubFinishValue
        {
            get
            {
                return this.SubInitValue - this.SubBalanceValue;
            }
        }
    }


}
