using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Quartz;

namespace B0250_Quartz.Jobs
{


    public class RecoveryJob : ManagerAbleJob
    {


        public override ExecuteJobResult ExecuteJob(IJobExecutionContext context)
        {

            JobKey key = context.JobDetail.Key;
            
            Console.WriteLine($"执行任务开始：{key} executing at {DateTime.Now:F}");

            try
            {
                Thread.Sleep(5000);
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex);
            }


            Console.WriteLine($"执行任务结束：{key} executing at {DateTime.Now:F}");


            return ExecuteJobResult.Success;
        }


    }


}
