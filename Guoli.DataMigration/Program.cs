using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace Guoli.DataMigration
{
    class Program
    {
        private static void Main(string[] args)
        {
            LogProvider.SetCurrentLogProvider(new ConsoleLogProvider());

            RunProgramRunExample().GetAwaiter().GetResult();

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }

        private static async Task RunProgramRunExample()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // define the job and tie it to our HelloJob class
                IJobDetail job = JobBuilder.Create<ImportDataJob>()
                    .WithIdentity("job1", "group1")
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .WithIdentity("trigger1", "group1")
                    .StartNow()
                    //.WithCronSchedule("40 08 17 * * ?")
                    .WithSimpleSchedule(x => x
                         .WithIntervalInHours(1)
                         .RepeatForever())
                    .Build();

                // Tell quartz to schedule the job using our trigger
                await scheduler.ScheduleJob(job, trigger);

                // some sleep to show what's happening
                //await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                // await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                Console.WriteLine(se);
            }
        }

        // simple log provider to get something to the console
        private class ConsoleLogProvider : ILogProvider
        {
            public Logger GetLogger(string name)
            {
                return (level, func, exception, parameters) =>
                {
                    if (level >= LogLevel.Info && func != null)
                    {
                        Console.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] [" + level + "] " + func(), parameters);
                    }
                    return true;
                };
            }

            public IDisposable OpenNestedContext(string message)
            {
                throw new NotImplementedException();
            }

            public IDisposable OpenMappedContext(string key, string value)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class ImportDataJob : IJob
    {
        private readonly List<IMigration> _tasks = new List<IMigration>();

        public ImportDataJob()
        {
            _tasks.Add(new DepartmentMigration());
            _tasks.Add(new PostMigragion());
            _tasks.Add(new StaffMigration());
            _tasks.Add(new DrivePlanMigration());
        }

        public async Task Execute(IJobExecutionContext context)
        {
            await Task.Factory.StartNew(() =>
            {
                _tasks.ForEach(task =>
                {
                    task.ImportNewData();
                    task.UpdateEditedData();
                });
            });
        }
    }
}
