using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0720_MultiTime.Sample
{

    /// <summary>
    ///  支持多次数据处理的类.
    /// </summary>
    public interface IMultiTimeProcessAble
    {

        /// <summary>
        /// 用于判断数据唯一性的 ID.
        /// </summary>
        /// <returns></returns>
        string GetID();


        /// <summary>
        /// 用于判断是否多次的 关键字.
        /// </summary>
        /// <returns></returns>
        string GetKeyWord();


        /// <summary>
        /// 获取处理日期
        /// （用于 排除 单日内多次 的情况）
        /// </summary>
        /// <returns></returns>
        DateTime GetProcessDate();

    }



}
