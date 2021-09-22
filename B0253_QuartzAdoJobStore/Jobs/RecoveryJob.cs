using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using log4net;
using Quartz;

namespace B0253_QuartzAdoJobStore.Jobs
{


    public class RecoveryJob : IJob
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public Task Execute(IJobExecutionContext context)
        {

            JobKey key = context.JobDetail.Key;


            return Task.Factory.StartNew(() =>
            {
                
                logger.Info($"执行任务开始：{key} executing at {DateTime.Now:F}");

                try
                {
                    Thread.Sleep(5000);
                } 
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                }


                logger.Info($"执行任务结束：{key} executing at {DateTime.Now:F}");

            });
        }


    }


}
