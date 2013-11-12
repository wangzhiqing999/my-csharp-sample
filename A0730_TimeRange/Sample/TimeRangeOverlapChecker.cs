using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0730_TimeRange.Sample
{
    /// <summary>
    /// 时间范围 重叠检查处理类.
    /// </summary>
    public class TimeRangeOverlapChecker
    {

        /// <summary>
        /// 两个时间段，是否存在 时间上的重叠.
        /// </summary>
        /// <param name="trMain"> 时间段1 (算法中，把第一个参数的时间段，认为是已存在的数据) </param>
        /// <param name="trNew)"> 时间段2 (算法中，把第二个参数的时间段，认为是准备新增的数据) </param>
        /// <param name="straightFlag)"> 连续标志 (为 true 的时候， 10:00--12:00 与 12:00--14:00 认为是没有重叠的， 为 false 的时候，认为是在 12:00 上有重叠) </param>
        /// <returns></returns>
        public static bool IsExistsTimeRangeOverlap(TimeRange trMain, TimeRange trNew, bool straightFlag = true)
        {
            // 下面的注释中的字符说明：
            // - 表示 空白时间段
            // + 表示 开始/结束的 标志位.
            // = 表示 时间段范围内


            // 首先判断 第一种情况.
            // 时间段1：----------+=====+-----
            // 时间段2：--------+====+--------
            // 或者
            // 时间段1：----------+=====+-----
            // 时间段2：----------+====+--------
            // 或者
            // 时间段1：----------+=====+-----
            // 时间段2：--------+==========+--
            // 或者
            // 时间段1：----------+=====+-----
            // 时间段2：----------+==========+--

            if (trNew.StartTime <= trMain.StartTime
                && trNew.EndTime > trMain.StartTime)
            {
                // 有重叠.
                return true;
            }


            // 然后判断第二种情况.
            // 时间段1：------+=========+-----
            // 时间段2：--------+====+--------
            // 或者
            // 时间段1：------+=========+-----
            // 时间段2：------+====+--------
            // 或者
            // 时间段1：------+=========+-----
            // 时间段2：--------+==========+--
            // 或者
            // 时间段1：------+=========+-----
            // 时间段2：------+==========+--

            if (trNew.StartTime >= trMain.StartTime
                && trNew.StartTime < trMain.EndTime)
            {
                // 有重叠.
                return true;
            }



            // 最后判断连续的情况.
            // 第一种情况.
            // 时间段1：----------+=====+-------------
            // 时间段2：-----+====+--------

            if (trNew.StartTime <= trMain.StartTime
                && trNew.EndTime == trMain.StartTime
                && !straightFlag)
            {
                // 时间连续，但是不允许连续
                // 有重叠.
                return true;
            }

            // 第二种情况.
            // 时间段1：------+=========+-------------
            // 时间段2：----------------+====+--------

            if (trNew.StartTime >= trMain.StartTime
                && trNew.StartTime == trMain.EndTime
                && !straightFlag)
            {
                // 时间连续，但是不允许连续
                // 有重叠.
                return true;
            }


            // 如果执行到了这里，那么认为是 参数的2个时间段 没有重叠。
            return false;
        }

    }
}
