using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0730_TimeRange.Sample
{


    /// <summary>
    /// 时间范围.
    /// </summary>
    public class TimeRange
    {

        /// <summary>
        /// 开始时间.
        /// (存储的数字， 千位与百位 为小时部分， 十位与个位 为分钟部分)
        /// </summary>
        public long StartTime { set; get; }


        /// <summary>
        /// 结束时间.
        /// (存储的数字， 千位与百位 为小时部分， 十位与个位 为分钟部分)
        /// </summary>
        public long EndTime { set; get; }


        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        public TimeRange(int iStart, int iEnd)
        {
            this.StartTime = iStart;
            this.EndTime = iEnd;
        }



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="iStart"></param>
        /// <param name="iEnd"></param>
        public TimeRange(DateTime dtStart, DateTime dtEnd)
        {
            // 开始
            this.StartTime = Convert.ToInt64(dtStart.ToString("yyyyMMddHHmmss"));
            // 结束.
            this.EndTime = Convert.ToInt64(dtEnd.ToString("yyyyMMddHHmmss"));
        }



        /// <summary>
        /// 构造函数.
        /// </summary>
        /// <param name="strStart"></param>
        /// <param name="strEnd"></param>
        public TimeRange(string strStart, string strEnd)
        {
            this.StartTime = Convert.ToInt32(strStart.Replace(":", ""));
            this.EndTime = Convert.ToInt32(strEnd.Replace(":", ""));
        }

    }

}
