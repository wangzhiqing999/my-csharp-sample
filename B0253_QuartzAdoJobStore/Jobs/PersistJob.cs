using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;


namespace B0253_QuartzAdoJobStore.Jobs
{

    /// <summary>
    /// 测试 持久化JobData.
    /// <br/>
    /// PersistJobDataAfterExecution：在执行完成后持久化JobData，该特性是针对Job类型生效的，意味着所有使用该Job的JobDetail都会在执行完成后持久化JobData。
    /// </summary>
    [PersistJobDataAfterExecution]
    public class PersistJob : IJob
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);




        /// <summary>
        /// 持久化数据.
        /// 这里简单使用一个 “执行次数” 作为持久化数据.
        /// </summary>
        public string ExecCount { get; set; }


        /// <summary>
        /// 持久化数据.
        /// 这里简单使用一个 “上一次运行时间” 作为持久化数据.
        /// </summary>
        public string PrevRunTime { get; set; }



        public Task Execute(IJobExecutionContext context)
        {

            return Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(PrevRunTime))
                {
                    ExecCount = "1";

                    logger.Info($"首次执行作业! 执行次数 {ExecCount}");
                }
                else
                {
                    logger.Info($"上一次执行作业时间： {PrevRunTime}!  执行次数 {ExecCount}");
                }

                int execCount = Convert.ToInt32(ExecCount);
                execCount++;

                // 持久化JobData.
                context.JobDetail.JobDataMap.Put("ExecCount", execCount.ToString());                
                context.JobDetail.JobDataMap.Put("PrevRunTime", DateTime.Now.ToLongTimeString());

            });
        }

    }
}
