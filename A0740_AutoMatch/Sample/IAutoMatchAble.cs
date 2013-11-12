using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0740_AutoMatch.Sample
{


    /// <summary>
    /// 支持自动匹配的类.
    /// </summary>
    public interface IAutoMatchAble
    {

        /// <summary>
        /// 用于判断数据唯一性的 ID.
        /// </summary>
        /// <returns></returns>
        string GetID();




        /// <summary>
        /// 本项目需要的消耗/花费.
        /// </summary>
        /// <returns></returns>
        decimal GetExpendValue();


    }

}
