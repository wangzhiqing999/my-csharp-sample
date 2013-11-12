using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

using A0730_TimeRange.Sample;



namespace A0730_TimeRange.Test
{


    [TestFixture]
    public class TimeRangeOverlapCheckerTest
    {





        /// <summary>
        ///IsExistsTimeRangeOverlap 的测试
        ///
        /// 允许 时间连续的情况.
        ///</summary>
        [Test]
        public void IsExistsTimeRangeOverlapTestStraightFlag()
        {
            // 系统中已有的时间段为  10:00 -- 12:00
            TimeRange trMain = new TimeRange(1000, 1200);

            bool actual;


            // 首先 8:00 -- 9:00 与 主数据 不存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(800, 900));

            // 不存在时间重叠.
            Assert.IsFalse(actual);


            // 允许连续的情况下  8:00 -- 10:00 与 主数据 不存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(800, 1000));

            // 不存在时间重叠.
            Assert.IsFalse(actual);


            // 允许连续的情况下  12:00 -- 14:00 与 主数据 不存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1200, 1400));

            // 不存在时间重叠.
            Assert.IsFalse(actual);


            // 13:00 -- 14:00 与 主数据 不存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1300, 1400));

            // 不存在时间重叠.
            Assert.IsFalse(actual);




            //  9:00 -- 11:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(900, 1100));

            // 存在时间重叠.
            Assert.IsTrue(actual);

            //  9:00 -- 12:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(900, 1200));

            // 存在时间重叠.
            Assert.IsTrue(actual);

            //  9:00 -- 13:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(900, 1300));

            // 存在时间重叠.
            Assert.IsTrue(actual);


            //  10:00 -- 11:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1000, 1100));

            // 存在时间重叠.
            Assert.IsTrue(actual);


            //  10:00 -- 12:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1000, 1200));

            // 存在时间重叠.
            Assert.IsTrue(actual);


            //  10:00 -- 13:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1000, 1300));

            // 存在时间重叠.
            Assert.IsTrue(actual);
        }







        /// <summary>
        ///IsExistsTimeRangeOverlap 的测试
        ///
        /// 不允许 时间连续的情况.
        ///</summary>
        [Test]
        public void IsExistsTimeRangeOverlapTestNotStraightFlag()
        {
            // 系统中已有的时间段为  10:00 -- 12:00
            TimeRange trMain = new TimeRange(1000, 1200);
            bool straightFlag = false;


            bool actual;


            // 首先 8:00 -- 9:00 与 主数据 不存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(800, 900),
                straightFlag);

            // 不存在时间重叠.
            Assert.IsFalse(actual);


            // 不允许连续的情况下  8:00 -- 10:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(800, 1000),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);


            // 不允许连续的情况下  12:00 -- 14:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1200, 1400),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);


            // 13:00 -- 14:00 与 主数据 不存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1300, 1400),
                straightFlag);

            // 不存在时间重叠.
            Assert.IsFalse(actual);




            //  9:00 -- 11:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(900, 1100),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);

            //  9:00 -- 12:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(900, 1200),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);

            //  9:00 -- 13:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(900, 1300),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);


            //  10:00 -- 11:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1000, 1100),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);


            //  10:00 -- 12:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1000, 1200),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);


            //  10:00 -- 13:00 与 主数据 存在时间重叠
            actual = TimeRangeOverlapChecker.IsExistsTimeRangeOverlap(
                trMain,
                new TimeRange(1000, 1300),
                straightFlag);

            // 存在时间重叠.
            Assert.IsTrue(actual);
        }


    }


}
