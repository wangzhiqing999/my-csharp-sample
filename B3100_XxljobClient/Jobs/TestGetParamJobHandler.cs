using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using log4net;

using com.xxl.job.core.biz.model;
using XxlJob.Core;



namespace B3100_XxljobClient.Jobs
{

    /// <summary>
    /// 测试获取参数.
    /// </summary>
    public class TestGetParamJobHandler : IJobHandler
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public override ReturnT Execute(JobExecutionContext context)
        {
            string param = context.ExecutorParams;

            logger.Info($"TestGetParamJobHandler 执行：参数={param}");


            return ReturnT.CreateSucceededResult("Success", $"TestGetParamJobHandler 执行：参数={param}");
        }


    }
}