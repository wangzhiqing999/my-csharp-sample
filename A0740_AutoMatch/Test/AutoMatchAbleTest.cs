using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using A0740_AutoMatch.Sample;

namespace A0740_AutoMatch.Test
{


    /// <summary>
    /// 用于  模拟   可兑换商品类.
    /// </summary>
    public class AutoMatchAbleTest : IAutoMatchAble
    {

        public AutoMatchAbleTest(string id, decimal expendValue)
        {
            this.ID = id;
            this.ExpendValue = expendValue;
        }



        /// <summary>
        /// 唯一性 ID。
        /// </summary>
        public string ID { set; get; }



        /// <summary>
        /// 消耗值.
        /// </summary>
        public decimal ExpendValue { set; get; }





        public string GetID()
        {
            return this.ID;
        }

        public decimal GetExpendValue()
        {
            return this.ExpendValue;
        }
    }
}
