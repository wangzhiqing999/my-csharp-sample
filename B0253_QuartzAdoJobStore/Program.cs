using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using Quartz;
using Quartz.Impl;


using B0253_QuartzAdoJobStore.Jobs;



namespace B0253_QuartzAdoJobStore
{
    class Program
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);





        /// <summary>
        /// 测试的方式：
        /// 运行，输入 1 或者 2
        /// 然后任务执行。
        /// 
        /// 然后 Ctrl+C 强制退出。
        /// 然后，再次运行。
        /// 观察之前的任务，是否能继续执行。
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Init();

            Console.WriteLine("----- Init Finish. -----");
                      
            string cmd;
            do
            {

                Console.WriteLine("Please Input Cmd: 1/2");
                cmd = Console.ReadLine();

                if(cmd == "1")
                {
                    p.TestPersistJob();
                }
                else if (cmd == "2")
                {
                    p.TestRecoveryJob();
                } 
                

            } while (cmd != "");



            Console.WriteLine("----- Exit. -----");

            p.Finish();

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
            properties["quartz.jobStore.misfireThreshold"] = "60000";
            properties["quartz.jobStore.type"] = "Quartz.Impl.AdoJobStore.JobStoreTX, Quartz";
            
            properties["quartz.jobStore.dataSource"] = "default";
            properties["quartz.jobStore.tablePrefix"] = "QRTZ_";
            properties["quartz.jobStore.clustered"] = "true";

            
            // https://www.quartz-scheduler.net/documentation/quartz-3.x/tutorial/job-stores.html#ado-net-job-store-adojobstore
            properties["quartz.jobStore.lockHandler.type"] = "Quartz.Impl.AdoJobStore.UpdateLockRowSemaphore, Quartz";
            properties["quartz.dataSource.default.connectionString"] = "Server=192.168.1.86;Database=quartznet;Uid=root;Pwd=123456;Charset=utf8";
            properties["quartz.dataSource.default.provider"] = "MySql";

            properties["quartz.jobStore.useProperties"] = "true";
            properties["quartz.serializer.type"] = "json";


            factory = new StdSchedulerFactory(properties);
            scheduler = await factory.GetScheduler();
            await scheduler.Start();
        }


        async void Finish()
        {
            await scheduler.Shutdown();
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
                    .WithIntervalInSeconds(5)
                    .WithRepeatCount(10))
                .Build();

            await scheduler.ScheduleJob(job, trigger);
        }




        /// <summary>
        /// 测试 RequestRecovery.
        /// </summary>
        void TestRecoveryJob()
        {

            // 计划运行 5 个作业.
            for (int i = 0; i < 5; i++)
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
                        .WithIntervalInSeconds(5)
                        .WithRepeatCount(10))
                    .Build();

                scheduler.ScheduleJob(job, trigger);
            }
        }




    }
}
