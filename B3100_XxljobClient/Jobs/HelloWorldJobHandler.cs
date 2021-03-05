using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

using log4net;

using com.xxl.job.core.biz.model;
using XxlJob.Core;

namespace B3100_XxljobClient.Jobs
{


    public class HelloWorldJobHandler : IJobHandler
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public override ReturnT Execute(JobExecutionContext context)
        {
            logger.Info("任务开始执行");

            Thread.Sleep(2500);

            logger.Info("任务执行结束");


            return ReturnT.CreateSucceededResult("测试job执行成功了!", "执行返回的内容");
        }

    }


}