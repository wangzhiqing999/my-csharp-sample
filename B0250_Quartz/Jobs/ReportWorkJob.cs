using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace B0250_Quartz.Jobs
{

    /// <summary>
    /// 报表工作的实现.
    /// </summary>
    public class ReportWorkJob : ManagerAbleJob
    {

        public override ExecuteJobResult ExecuteJob(IJobExecutionContext context)
        {

            JobKey key = context.JobDetail.Key;

            // 准备用于获取外部的参数.
            JobDataMap dataMap = context.JobDetail.JobDataMap;


            // 从参数中，获取报表ID.
            long reportId = dataMap.GetLong("ReportId");

            // 从参数中，获取报表参数.
            string reportParams = dataMap.GetString("ReportParams");


            System.Threading.Thread.Sleep(5000);

            Console.WriteLine($"【作业 {key}】: 生成报表，代码 {reportId}；参数 {reportParams}");


            return ExecuteJobResult.Success;
        }

    }
}
