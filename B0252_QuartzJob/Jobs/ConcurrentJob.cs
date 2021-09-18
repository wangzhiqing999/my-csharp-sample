using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using System.Threading.Tasks;
using log4net;
using Quartz;



namespace B0252_QuartzJob.Jobs
{


    public class ConcurrentJob : IJob
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// 执行次数.
        /// </summary>
        private static int _ExecuteCount = 0;



        public Task Execute(IJobExecutionContext context)
        {

            JobKey key = context.JobDetail.Key;


            return Task.Factory.StartNew(() =>
            {

                _ExecuteCount++;


                logger.Info($"========== 执行任务 {_ExecuteCount} 开始：{key} executing at {DateTime.Now:F}");

                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                }


                logger.Info($"========== 执行任务 {_ExecuteCount} 结束：{key} executing at {DateTime.Now:F}");

            });
        }


    }


    [DisallowConcurrentExecution]
    public class DisallowConcurrentJob : IJob
    {
        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// 执行次数.
        /// </summary>
        private static int _ExecuteCount = 0;



        public Task Execute(IJobExecutionContext context)
        {

            JobKey key = context.JobDetail.Key;


            return Task.Factory.StartNew(() =>
            {

                _ExecuteCount++;


                logger.Info($"---------- 执行任务 {_ExecuteCount} 开始：{key} executing at {DateTime.Now:F}");

                try
                {
                    Thread.Sleep(5000);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message, ex);
                }


                logger.Info($"---------- 执行任务 {_ExecuteCount} 结束：{key} executing at {DateTime.Now:F}");

            });
        }


    }
}
