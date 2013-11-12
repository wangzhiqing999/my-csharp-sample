using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A0110_DateTime.Sample
{
    class DateTimeSample
    {

        /// <summary>
        /// 测试 DateTime 的使用.
        /// </summary>
        public void TestDateTimeUse()
        {
            // 取得当前时间.
            DateTime now = DateTime.Now;
            Console.WriteLine("现在时间是：{0}", now.ToString());

            // 只要日期，不要时间.
            DateTime day = DateTime.Today;
            Console.WriteLine("今天日期是：{0}", day.ToString());

            // 格式化输出:
            Console.WriteLine("今天日期是：{0}", day.ToString("yyyy-M-dd"));

            Console.WriteLine("今天日期是：{0}", day.ToString("yyyy MMMM dd dddd"));
        }



        /// <summary>
        /// 测试 TimeSpan
        /// </summary>
        public void TestTimeSpanUse()
        {
            DateTime dt = new DateTime(2010, 1, 1);
            DateTime dt2 = new DateTime(2010, 1, 1);
            Console.WriteLine("初始日期是：{0}", dt.ToString());


            TimeSpan elapsedTime = new TimeSpan(TimeSpan.TicksPerDay);
            dt += elapsedTime;
            Console.WriteLine("初始日期增加一天以后是：{0}", dt.ToString());
            Console.WriteLine("时间间隔：{0}", dt - dt2);


            elapsedTime = new TimeSpan(TimeSpan.TicksPerHour);
            dt += elapsedTime;
            Console.WriteLine("再增加一小时以后是：{0}", dt.ToString());
            Console.WriteLine("时间间隔：{0}", dt - dt2);


            elapsedTime = new TimeSpan(TimeSpan.TicksPerMinute);
            dt += elapsedTime;
            Console.WriteLine("再增加一分以后是：{0}", dt.ToString());
            Console.WriteLine("时间间隔：{0}", dt - dt2);


            elapsedTime = new TimeSpan(TimeSpan.TicksPerSecond);
            dt += elapsedTime;
            Console.WriteLine("再增加一秒以后是：{0}", dt.ToString());
            Console.WriteLine("时间间隔：{0}", dt - dt2);


            // 注意：
            // DateTime 的增减
            // 对于 月单位以下的， 可以使用 TimeSpan 进行计算处理， 也可以使用 DateTime 自带的方法.
            // 
            // 对于 月以上的单位（含月）的处理，直接使用 DateTime 自带的方法.

            dt = dt.AddMonths(1);
            Console.WriteLine("再增加一个月以后是：{0}", dt.ToString());
            Console.WriteLine("时间间隔：{0}", dt - dt2);


            dt = dt.AddYears(1);
            Console.WriteLine("再增加一个年以后是：{0}", dt.ToString());
            Console.WriteLine("时间间隔：{0}", dt - dt2);


            

        }



    }
}
