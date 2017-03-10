using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Common.Logging.Simple;
using Quartz;
using Quartz.Impl;

namespace Guoli.Utilities.Helpers
{
    /// <summary>
    /// Quartz.Net帮助类，简化使用Quartz.Net执行定时任务的代码
    /// </summary>
    public static class QuartzHelper
    {
        class QuartzJob : IJob
        {
            public void Execute(IJobExecutionContext context)
            {
                _task?.Invoke();
            }
        }

        private static Action _task;

        public static void DoJobWithQuartz(Action jobAction, string cronExpression)
        {
            _task = jobAction;

            LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter { Level = LogLevel.Info };

            var scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();

            var jobName = Guid.NewGuid().ToString();
            var groupName = Guid.NewGuid().ToString();
            var jobDetail = JobBuilder.Create<QuartzJob>()
                .WithIdentity(jobName, groupName)
                .Build();

            var triggerName = Guid.NewGuid().ToString();
            var trigger = TriggerBuilder.Create()
                .WithIdentity(triggerName, groupName)
                .StartNow()
                .WithCronSchedule(cronExpression)
                .Build();
            
            scheduler.ScheduleJob(jobDetail, trigger);
        }
    }
}
