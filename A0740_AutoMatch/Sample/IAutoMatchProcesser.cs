using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0740_AutoMatch.Sample
{
    
    /// <summary>
    /// 自动匹配处理.
    /// 
    /// 当某个时间点上， 需要完整 “帐户清零” 的处理时。
    /// 系统需要自动按照  帐户的剩余点数， 做自动匹配的消耗处理。
    /// 
    /// </summary>
    public interface IAutoMatchProcesser
    {


        /// <summary>
        /// 可消耗的商品列表
        /// </summary>
        List<IAutoMatchAble> BaseDataList{set;get;}


        /// <summary>
        /// 处理完毕后， 节余点数.
        /// </summary>
        decimal RemainderValue { get; }



        /// <summary>
        /// 自动匹配处理.
        /// </summary>
        /// <returns> 匹配后的结果. </returns>
        List<AutoMatchResult> DoAutoMatchProcess(decimal currentValue);
        



    }


}
