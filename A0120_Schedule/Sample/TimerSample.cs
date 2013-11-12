using System;
using System.Timers;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace A00120_Schedule.Sample
{

    class TimerSample
    {

        // 定时器.
        Timer aTimer = null;


        /// <summary>
        /// 指定时间安排时间执行的例子
        /// </summary>
        public void TestTimer()
        {
            // 构造函数. 指定周期为：10000 毫秒 = 10秒
            aTimer = new System.Timers.Timer(10000);

            // 指定 每隔那么多秒以后， 所需要触发的事件。
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);

            // 开始定时处理.
            aTimer.Enabled = true;

        }



        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("使用 Timer 定时处理业务： {0}", e.SignalTime);
        }


    }

}
