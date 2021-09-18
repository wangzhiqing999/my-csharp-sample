using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

using Quartz;
using Quartz.Impl;

using B0252_QuartzJob.Jobs;


namespace B0252_QuartzJob
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

            p.TestSayHelloJob();

            p.TestPersistJob();
            */

            // p.TestRecoveryJob();

            p.TestConcurrentJob();

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
            factory = new StdSchedulerFactory();
            scheduler = await factory.GetScheduler();
            await scheduler.Start();
        }




        /// <summary>
        /// 测试 HelloJob.
        /// </summary>
        async void TestHelloJob()
        {
            IJobDetail job = JobBuilder.Create<HelloJob>()
                // WithIdentity：作业的唯一标识.
                .WithIdentity("HelloJob", "DemoGroup")
                // WithDescription：作业的描述信息.
                .WithDescription("最简单的作业.")
                .Build();

            
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("HelloTrigger", "DemoGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }


        /// <summary>
        /// 测试 SayHelloJob.
        /// </summary>
        async void TestSayHelloJob()
        {
            IJobDetail job = JobBuilder.Create<SayHelloJob>()
                // WithIdentity：作业的唯一标识.
                .WithIdentity("SayHelloJob", "DemoGroup")
                // WithDescription：作业的描述信息.
                .WithDescription("带参数的作业.")
                // 这里设置参数.
                .SetJobData(new JobDataMap() {
                                new KeyValuePair<string, object>("UserName", "Tom")
                            })
                .Build();


            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("SayHelloTrigger", "DemoGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }


        /// <summary>
        /// 测试 PersistJob.
        /// </summary>
        async void TestPersistJob()
        {
            IJobDetail job = JobBuilder.Create<PersistJob>()
                // WithIdentity：作业的唯一标识.
                .WithIdentity("PersistJob", "DemoGroup")
                // WithDescription：作业的描述信息.
                .WithDescription("持久化JobData的作业.")
                .Build();


            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("PersistTrigger", "DemoGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(30)
                    .RepeatForever())
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }




        /// <summary>
        /// 暂时不确定怎么测这个 RequestRecovery.
        /// </summary>
        void TestRecoveryJob()
        {

            // 计划运行 5 个作业.
            for(int i = 0; i < 5; i++)
            {
                IJobDetail job = JobBuilder.Create<RecoveryJob>()
                // WithIdentity：作业的唯一标识.
                .WithIdentity($"RecoveryJob_{i}", "DemoGroup")
                // WithDescription：作业的描述信息.
                .WithDescription("用于测试 RequestRecovery 的作业.")
                .RequestRecovery(true)
                .Build();


                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity($"RecoveryTrigger_{i}", "DemoGroup")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(3)
                        .RepeatForever())
                    .Build();

                scheduler.ScheduleJob(job, trigger);
            }
        }






        /// <summary>
        /// 测试 DisallowConcurrentExecution：禁止并行执行，该特性是针对JobDetail生效的
        /// 
        /// 作业耗时 5 秒.
        /// 触发器是 立即执行， 然后每 3秒执行1次， 再执行 10次。
        /// </summary>
        void TestConcurrentJob()
        { 

            // 这里是允许并行执行的操作.
            // 第一个作业执行 3 秒后，后续触发，将并行执行作业。
            IJobDetail job = JobBuilder.Create<ConcurrentJob>()
                // WithIdentity：作业的唯一标识.
                .WithIdentity($"ConcurrentJob", "DemoGroup")
                // WithDescription：作业的描述信息.
                .WithDescription("用于测试 DisallowConcurrentExecution 的作业.")
                .Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity($"ConcurrentTrigger", "DemoGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3)
                    .WithRepeatCount(10))
                .Build();

            scheduler.ScheduleJob(job, trigger);



            // 这里是不允许并行执行的操作.
            // 第一个作业执行 3 秒后，后续触发，将等待第一个作业执行完毕后，再执行后续的作业。
            IJobDetail job2 = JobBuilder.Create<DisallowConcurrentJob>()
            // WithIdentity：作业的唯一标识.
            .WithIdentity($"DisallowConcurrentJob", "DemoGroup")
            // WithDescription：作业的描述信息.
            .WithDescription("用于测试 DisallowConcurrentExecution 的作业.")
            .Build();


            ITrigger trigger2 = TriggerBuilder.Create()
                .WithIdentity($"DisallowConcurrentTrigger", "DemoGroup")
                .StartNow()
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(3)
                    .WithRepeatCount(10))
                .Build();

            scheduler.ScheduleJob(job2, trigger2);




        }





    }
}
