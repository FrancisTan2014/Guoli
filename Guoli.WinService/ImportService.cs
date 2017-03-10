using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Guoli.DataMigration;
using Guoli.Utilities.Helpers;

namespace Guoli.WinService
{
    public class ImportService: ServiceBase
    {
        protected override void OnStart(string[] args)
        {
            var cronExpr = ConfigurationManager.AppSettings["QuartzCronExpression"];
            QuartzHelper.DoJobWithQuartz(OracleMigrationTask.ExecuteDataSynchronization, cronExpr);

            base.OnStart(args);
        }

        private void InitializeComponent()
        {
            // 
            // ImportService
            // 
            this.CanHandlePowerEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.ServiceName = "DataSyncService";

        }
    }
}
