using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

using System.Threading;
using System.IO;


namespace WS002_Schedule
{
    public partial class ScheduleService : ServiceBase
    {

        /// <summary>
        /// 服务配置信息.
        /// </summary>
        private Properties.Settings config = Properties.Settings.Default;


        /// <summary>
        /// 服务线程.
        /// </summary>
        private Thread serviceThread;



        /// <summary>
        /// 构造函数.
        /// </summary>
        public ScheduleService()
        {
            InitializeComponent();
        }



        /// <summary>
        /// 服务启动.
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            ThreadStart ts = new ThreadStart(ServiceThreadFunc);
            serviceThread = new Thread(ts);
            serviceThread.Start();

        }



        /// <summary>
        /// 服务停止.
        /// </summary>
        protected override void OnStop()
        {

            // 如果服务线程， 正在运行过程中的， 那么强制停止掉.
            if (serviceThread != null && serviceThread.IsAlive)
            {
                serviceThread.Abort();
            }

        }





        /// <summary>
        /// 服务线程处理.
        /// </summary>
        public void  ServiceThreadFunc()
        {
            // 从配置信息中， 取得  启动时间.
            TimeSpan myTime = config.ScheduleTime;

            // 线程停止运行的标志位.
            bool done = false;

            while (!done)
            {

                // 小时 / 分钟一致， 则执行处理.
                string fileName = String.Format(@"{0}{1}\{2}.txt",
                    System.AppDomain.CurrentDomain.BaseDirectory,
                    config.DataPath,
                    DateTime.Today.ToString("yyyyMMdd"));


                // 当前时间.
                TimeSpan now = DateTime.Now.TimeOfDay;

                if (myTime.Hours == now.Hours
                    && myTime.Minutes == now.Minutes)
                {

                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
                    {
                        sw.WriteLine(String.Format("ScheduleService 运行中，预期要求运行时间：{0}，当前处理时间：{1}。", myTime, DateTime.Now));

                        sw.WriteLine("业务处理开始......");

                        Thread.Sleep(60 * 1000);

                        sw.WriteLine("业务处理结束......");

                        sw.Flush();
                    }
                }
                else
                {

                    using (StreamWriter sw = new StreamWriter(fileName, true, Encoding.UTF8))
                    {
                        sw.WriteLine(String.Format("ScheduleService 运行中，预期要求运行时间：{0}，当前处理时间：{1}。时间未到需要执行的时间！", myTime, DateTime.Now));
                        sw.Flush();
                    }

                }


                Thread.Sleep(55 * 1000);
            }
        }


    }
}
