using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;


namespace B0252_QuartzJob.Jobs
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
        /// 这里简单使用一个 “上一次运行时间” 作为持久化数据.
        /// </summary>
        public string PrevRunTime { get; set; }



        public Task Execute(IJobExecutionContext context)
        {

            return Task.Factory.StartNew(() =>
            {
                if (string.IsNullOrEmpty(PrevRunTime))
                {
                    logger.Info($"首次执行作业!");
                }
                else
                {
                    logger.Info($"上一次执行作业时间： {PrevRunTime}!");
                }



                // 持久化JobData.
                context.JobDetail.JobDataMap.Put("PrevRunTime", DateTime.Now.ToLongTimeString());

            });
        }

    }
}
