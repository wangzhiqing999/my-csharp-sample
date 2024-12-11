using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace B0250_Quartz.Jobs
{
    public class HelloJob : ManagerAbleJob
    {




        public override ExecuteJobResult ExecuteJob(IJobExecutionContext context)
        {

            Console.WriteLine("HelloJob is executing.");

            return ExecuteJobResult.Success;

        }

    }
}
