


基本使用步骤
NuGet 安装 Quartz 



大概步骤如下:
1.继承作业接口Ijob建立job
2.建立作业调度器Scheduler
3.通过JobBuilder生成一个任务job
4.通过TriggerBuilder建立一个触发器trigger
5.将job和trigger加入调度器Scheduler中




最基本的操作对象：  IJobDetail、ITrigger、IScheduler



IJobDetail - 任务 （包含：做什么？名称？组）
例：
IJobDetail job = JobBuilder.Create<HelloJob>()
	.WithIdentity("myJob", "group1")
	.Build();
				
				

ITrigger - 触发器 （包含：名称？组？触发的间隔）
例：
ITrigger trigger = TriggerBuilder.Create()
	.WithIdentity("myTrigger", "group1")
	.StartNow()
	.WithSimpleSchedule(x => x
		.WithIntervalInSeconds(40)
		.RepeatForever())
	.Build();




IScheduler - 调度器.
// 将任务与触发器添加到调度器中
scheduler.ScheduleJob(job, trigger);
// 开始执行
scheduler.Start();



