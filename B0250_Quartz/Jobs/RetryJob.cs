using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B0250_Quartz.Jobs
{

    public class RetryJob : ManagerAbleJob
    {

        public override ExecuteJobResult ExecuteJob(IJobExecutionContext context)
        {
            try
            {

                int second = DateTime.Now.Second;

                if (second % 2 == 0)
                {
                    // 模拟失败， 好让调度器重试。
                    return new ExecuteJobResult()
                    {
                        ResultCode = "ERR",
                        ResultMessage = "模拟失败！",
                    };
                }

                System.Threading.Thread.Sleep(1000);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            return ExecuteJobResult.Success;
        }
    }
}
