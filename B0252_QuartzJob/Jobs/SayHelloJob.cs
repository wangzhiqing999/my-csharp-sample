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
    /// 测试接收一个参数.
    /// </summary>
    public class SayHelloJob : IJob
    {


        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        /// <summary>
        /// Job 的参数.
        /// </summary>
        public string UserName { get; set; }


        public Task Execute(IJobExecutionContext context)
        {
            return Task.Factory.StartNew(() =>
            {
                logger.Info($"Hello {UserName}!");
            });
        }
    }
}
