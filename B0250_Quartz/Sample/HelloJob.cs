using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using Quartz;

namespace B0250_Quartz.Sample
{
    public class HelloJob : IJob
    {

        /// <summary>
        /// 日志处理类.
        /// </summary>
        private static ILog logger = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);



        public async Task Execute(IJobExecutionContext context)
        {
            logger.Info("HelloJob Start!");

            await Console.Out.WriteLineAsync("HelloJob is executing.");
        }


    }
}
