using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



using System.Timers;
using System.Threading;



namespace A0360_Timers
{
    class Program
    {

        /// <summary>
        /// 定期处理类.
        /// </summary>
        private static System.Timers.Timer aTimer;



        static void Main(string[] args)
        {

            Console.WriteLine("程序运行开始：{0}", DateTime.Now);


            //  创建一个定时器， 周期为  1 秒. （那个参数的单位是 毫秒）
            aTimer = new System.Timers.Timer(1000);

            // 定义好触发的事件.
            aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);


            // 指示 Timer 引发 Elapsed 事件。
            // 设置此属性值以后，才开始处理.
            aTimer.Enabled = true;


            // 让作业能够先迅速执行一次.
            Thread.Sleep(1500);


            // 修改周期为 5 秒 (5000 milliseconds).
            // 此操作将覆盖掉 构造函数中的 1秒的设置.
            aTimer.Interval = 5000;


            


            Console.WriteLine("Press the Enter key to exit the program.");
            Console.ReadLine();


            // 某些情况下， 可能需要增加一行    GC.KeepAlive(aTimer);  的处理代码.
        }





        /// <summary>
        /// 定时器  定时触发的事件.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("定时器事件触发于： {0}", e.SignalTime);
        }



    }
}
