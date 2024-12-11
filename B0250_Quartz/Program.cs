using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using Quartz;
using Quartz.Impl;

using B0250_Quartz.Sample;
using System.Collections.Specialized;

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

            /*
             
            p.TestHelloJob();

            p.TestParamJob();

            p.TestParam2Job();

            p.TestCron();

            */



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


            NameValueCollection properties = new NameValueCollection();

            properties["quartz.scheduler.instanceName"] = "TestScheduler";
            properties["quartz.scheduler.instanceId"] = "instance_one";
            properties["quartz.threadPool.type"] = "Quartz.Simpl.SimpleThreadPool, Quartz";
            properties["quartz.threadPool.threadCount"] = "5";
            properties["quartz.threadPool.threadPriority"] = "Normal";





            // 下面的配置信息，是将作业的数据， 由默认的存储在内存，变更为存储在数据库。
            // 使得作业发生故障时，能够从数据库，重新加载数据，进行恢复的处理.
            properties["quartz.jobStore.misfireThreshold"] = "60000";
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            properties["quartz.jobStore.dataSource"] = "default";
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            properties["quartz.jobStore.clustered"] = "true";

            // https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/job-stores.html#ado-net-job-store-adojobstore
            properties["quartz.jobStore.lockHandler.type"] = "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz";
            properties["quartz.dataSource.default.connectionString"] = "Server=pve002;Database=quartznet;Uid=root;Pwd=123456;Charset=utf8mb4";
            properties["quartz.dataSource.default.provider"] = "MySql";
            properties["quartz.jobStore.useProperties"] = "true";
            properties["quartz.serializer.type"] = "json";


            // construct a scheduler factory using properties
            factory = new StdSchedulerFactory(properties);

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
