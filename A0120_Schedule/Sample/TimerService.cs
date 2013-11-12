using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace A00120_Schedule.Sample
{

    /// <summary>
    /// 这个类用于实现：
    /// 
    /// 程序中存在一个循环，每个循环执行一项操作，
    /// 该操作耗时较长。希望在单个循环中设置一个超时，
    /// 超过指定时间结束此次循环进行下一次。
    /// </summary>
    public class TimerService
    {
        private Thread myThread;
        /// <summary>
        /// 启动线程.
        /// </summary>
        public void DoMainFunc()
        {
            RestartSubService(this);
        }
        /// <summary>
        /// 定时重新调用子处理逻辑.   如果上一次没有执行完，那么优先停止掉.
        /// </summary>
        /// <param name="threadObj"></param>
        private void RestartSubService(Object threadObj)
        {
            Console.WriteLine("#{0:hh:mm:ss}##定时处理开始执行！", DateTime.Now);
            TimerService t = threadObj as TimerService;
            // 如果线程还没运行结束，那么 Abort 掉.
            if (t.myThread != null && t.myThread.IsAlive)
            {
                try
                {
                    t.myThread.Abort();
                }
                catch { }
            }
            // 开始新的线程处理.
            t.myThread = new Thread(new ThreadStart(DoSubFunc));
            t.myThread.Start();
            // 5秒后再次执行.
            TimerCallback tcb = RestartSubService;
            Timer aTimer = new Timer(tcb, this, 5000, Timeout.Infinite);
        }
        /// <summary>
        /// 子处理逻辑
        /// </summary>
        private void DoSubFunc()
        {
            try
            {
                Random r = new Random();
                int second = r.Next(20);
                Console.WriteLine("#{0:hh:mm:ss}#####我是子线程， 我想运行{1}秒！", DateTime.Now, second);
                // 休眠 second 秒.
                Thread.Sleep(second * 1000);
                Console.WriteLine("#{0:hh:mm:ss}##### 我是子线程， 我处理结束！", DateTime.Now);
            }
            catch
            {
                Console.WriteLine("#{0:hh:mm:ss}##### 我是子线程，我运行超过时间了，我被干掉了！", DateTime.Now);
            }
        }
    }
}
