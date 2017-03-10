using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using Guoli.Utilities.Helpers;

namespace Guoli.WinService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[]
            {
                new ImportService()
            };
            ServiceBase.Run(servicesToRun);
        }
    }
}
