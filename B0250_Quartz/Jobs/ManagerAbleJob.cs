using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


using Quartz;

namespace B0250_Quartz.Jobs
{

    /// <summary>
    /// 作业的基类.
    /// <br/>
    /// 在作业执行前，与执行后，会输出相关的日志.
    /// </summary>
    public abstract class ManagerAbleJob : IJob
    {
        public abstract ExecuteJobResult ExecuteJob(IJobExecutionContext context);



        public async Task Execute(IJobExecutionContext context)
        {
            JobKey key = context.JobDetail.Key;

            Console.WriteLine($"### {DateTime.Now:yyyy-MM-dd HH:mm:ss} ### Job:{key.Name} is executing on thread:{Thread.CurrentThread.ManagedThreadId}");

            var result = ExecuteJob(context);

            if (result != null && result.ResultCode != "0")
            {
                // 出错了. 重试.
                var oldTrigger = context.Trigger;

                // 基础触发器的名称.
                string basicTriggerKeyName = GetBasicTriggerKeyName(oldTrigger.Key.Name);
                // 重试次数.
                int retryCount = GetRetryCount(oldTrigger.Key.Name);

                if(retryCount < 3)
                {
                    // 重试次数小于3次，尝试重试.
                    retryCount++;

                    // 新的触发器名称.
                    string newTriggerName = $"{basicTriggerKeyName}-retry{retryCount}";


                    var newTrigger = TriggerBuilder.Create()
                        .ForJob(context.JobDetail)
                        .WithIdentity(newTriggerName, oldTrigger.Key.Group)
                        .StartAt(DateTimeOffset.UtcNow.AddSeconds(30))
                        .Build();

                    await context.Scheduler.ScheduleJob(newTrigger);
                }

                
            }

            Console.WriteLine($"### {DateTime.Now:yyyy-MM-dd HH:mm:ss} ### Job:{key.Name} is completed with result:{result}");
            Console.WriteLine();

        }



        private string GetBasicTriggerKeyName(string triggerKeyName)
        {
            string[] nameArray = triggerKeyName.Split('-');

            if (nameArray.Length <= 1)
            {
                // 没有重试的处理.
                return triggerKeyName;
            }

            string retryStr = nameArray.Last();

            string name = triggerKeyName.Replace($"-{retryStr}", "");

            return name;
        }

        private int GetRetryCount(string triggerKeyName)
        {
            string[] nameArray = triggerKeyName.Split('-');
            if(nameArray.Length <= 1)
            {
                // 没有重试的处理.
                return 0;
            }

            string retryStr = nameArray.Last();
            if(!retryStr.StartsWith("retry"))
            {
                return 0;
            }

            retryStr= retryStr.Substring(5);

            return Convert.ToInt32(retryStr);
        }
    }





    public class ExecuteJobResult
    {
        public string ResultCode { get; set; }
        public string ResultMessage { get; set; }


        public override string ToString()
        {
            return $"code={this.ResultCode};message={this.ResultMessage}";
        }



        public static ExecuteJobResult Success
        {
            get
            {
                return new ExecuteJobResult(){
                    ResultCode = "0",
                    ResultMessage = "success" 
                };
            }
        }


    }


}
