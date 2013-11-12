using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0750_MainSub.Sample
{


    /// <summary>
    /// 主数据 
    /// （真实数据）
    /// </summary>
    public class MainData
    {

        /// <summary>
        /// 主数据的代码.
        /// </summary>
        public virtual string MainDataCode { set; get; }



        /// <summary>
        /// 主数据的数值.
        /// </summary>
        public virtual decimal MainInitValue { set; get; }


        /// <summary>
        /// 主数据的余额.
        /// </summary>
        public virtual decimal MainBalanceValue { set; get; }



        /// <summary>
        /// 主数据 所关联的 子数据列表.
        /// </summary>
        public virtual List<ISubData> SubDataList { set; get; }







        #region 基本方法.


        /// <summary>
        /// 初始化 子数据列表
        /// </summary>
        public virtual void InitSubDataList()
        {
            SubDataList = new List<ISubData>();
        }



        /// <summary>
        /// 余额检查.
        /// </summary>
        /// <returns></returns>
        public bool BalanceValueCheck()
        {
            // 子数据的余额.
            decimal subDataBalanceValue = 0;

            if (this.SubDataList != null)
            {
                // 子数据不为空.
                subDataBalanceValue = this.SubDataList.Sum(p => p.SubBalanceValue);
            }

            // 返回 (主数据余额， 是否等于  子数据余额的合计值).
            return this.MainBalanceValue == subDataBalanceValue;
        }




        #endregion


    }
}
