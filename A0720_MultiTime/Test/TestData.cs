using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0720_MultiTime.Sample;

namespace A0720_MultiTime.Test
{

    class TestData : IMultiTimeProcessAble
    {

        /// <summary>
        /// VIP 会员代码.
        /// </summary>
        public string VipNo { set; get; }


        /// <summary>
        /// 发票号.
        /// </summary>
        public string SalesNo { set; get; }


        /// <summary>
        /// 销售金额.
        /// </summary>
        public decimal SalesAmt { set; get; }


        /// <summary>
        /// 销售日期.
        /// </summary>
        public DateTime SalesDate { set; get; }




        public override string ToString()
        {
            return String.Format("会员代码:{0};  发票号：{1}; 销售额:{3}; 销售日期：{4}", VipNo, SalesNo, SalesAmt, SalesDate);
        }




        /// <summary>
        /// 唯一标示.
        /// </summary>
        /// <returns></returns>
        public string GetID()
        {
            return this.SalesNo;
        }


        /// <summary>
        /// 分组关键字.
        /// </summary>
        /// <returns></returns>
        public string GetKeyWord()
        {
            return this.VipNo;
        }


        /// <summary>
        /// 日期关键字.
        /// </summary>
        /// <returns></returns>
        public  DateTime GetProcessDate()
        {
            return this.SalesDate;
        }
    }
}
