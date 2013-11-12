using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P0105_Multiton.Sample
{
    /// <summary>
    /// 本类并不是真正意义上的 i18n 的处理
    /// 
    /// 只是用于 演示 不确定数量的多例。
    /// </summary>
    public class I18n
    {
        /// <summary>
        /// 多例的内部缓存.
        /// </summary>
        private static readonly Dictionary<string, I18n> i18nCache = new Dictionary<string, I18n>();


        /// <summary>
        /// 私有的构造函数.
        /// 必须的
        /// </summary>
        private I18n()
        {
        }


        /// <summary>
        /// 获取 实例.
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public static I18n GetInstance(string country)
        {
            if (i18nCache.ContainsKey(country))
            {
                // 内部数据集合中有数据.
                return i18nCache[country];
            }
            else
            {
                // 内部数据集合中无数据.
                I18n newDate = new I18n();
                i18nCache.Add(country, newDate);
                return newDate;
            }
        }




        /// <summary>
        /// 用于演示多例的 有效性.
        /// </summary>
        public int DemoCount { set; get; }



    }
}
