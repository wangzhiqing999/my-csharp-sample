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
    /// 测试最简单的 Hello.
    /// </summary>
    public class HelloJob : IJob
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public Task Execute(IJobExecutionContext context)
        {
            logger.Info("HelloJob Start!");

            return Task.CompletedTask;
        }


    }
}
