using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using Quartz;
using Quartz.Impl;

using B0250_Quartz.Sample;

namespace B0250_Quartz
{
    class Program
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        static void Main(string[] args)
        {

            Program p = new Program();
            p.Init();


            p.TestHelloJob();

            p.TestParamJob();

            p.TestParam2Job();

            p.TestCron();



            Console.WriteLine("----- Press Enter To Quit. -----");
            Console.ReadLine();
        }










        private StdSchedulerFactory factory;

        private IScheduler scheduler;


        /// <summary>
        /// 初始化.
        /// </summary>
        async void Init()
        {
            // construct a scheduler factory using defaults
            factory = new StdSchedulerFactory();

            // get a scheduler
            scheduler = await factory.GetScheduler();
            await scheduler.Start();
        }





        /// <summary>
        /// 测试一个 HelloJob.
        /// </summary>
        async void TestHelloJob()
        {
            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<HelloJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(40)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }



        /// <summary>
        /// 测试调用任务的时候， 额外传递参数.
        /// </summary>
        void TestParamJob()
        {
            IJobDetail job = JobBuilder.Create<TestParamJob>()
                .WithIdentity("myJob", "group2")
                // 额外传递给任务的参数。
                .UsingJobData("jobSays", "Hello World!")
                .UsingJobData("myFloatValue", 3.141f)
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group2")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(60)
                    // .RepeatForever()
                    )
                .Build();

            scheduler.ScheduleJob(job, trigger);
        }


        /// <summary>
        /// 测试调用任务的时候， 额外传递参数.
        /// </summary>
        void TestParam2Job()
        {
            IJobDetail job = JobBuilder.Create<TestParam2Job>()
                .WithIdentity("myJob2", "group2")
                // 额外传递给任务的参数。
                .UsingJobData("jobSays", "Hello World!")
                .UsingJobData("myFloatValue", 3.141f)
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger2", "group2")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(60)
                    // .RepeatForever()
                    )
                .Build();

            scheduler.ScheduleJob(job, trigger);

        }




        /// <summary>
        /// 测试使用  Cron 表达式
        /// </summary>
        void TestCron()
        {
            IJobDetail job = JobBuilder.Create<TestParam2Job>()
                .WithIdentity("myJob3", "group3")
                // 额外传递给任务的参数。
                .UsingJobData("jobSays", "Test CronTriggers")
                .UsingJobData("myFloatValue", 123.456f)
                .Build();


            // 使用 Cron 表达式， 时间在 0秒、30秒的时候触发.
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger3", "group3")
                .WithCronSchedule("0,30 * * * * ? *")
                .Build();


            scheduler.ScheduleJob(job, trigger);
        }


    }
}
