using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guoli.Utilities.LicenseHelper;

namespace Guoli.Import
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            // 激活 Aspose.Words、Aspose.Pdf 等 Aspose 系统组件
            ModifyInMemory.ActivateMemoryPatching();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmInit());
            //Application.Run(new frmImport());
        }
    }
}
