using Guoli.DataMigration;
using Guoli.Model;
using Guoli.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Guoli.Bll;
using Guoli.Utilities.Extensions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;

namespace Guoli.Import
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 车站-线路-车次导入
        /// 点击按钮提示选择文件
        /// </summary>
        private void btnStations_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    TimeTableImporter.Execute(ofd.FileName);

                    MessageBox.Show(@"导入成功！");
                }
            }
        }

        /// <summary>
        /// 手动执行同步运安数据库数据的操作
        /// </summary>
        private void btnMigration_Click(object sender, EventArgs e)
        {
            OracleMigrationTask.ExecuteDataSynchronization();
        }

        /// <summary>
        /// 系统初次部署时，添加管理员账号
        /// </summary>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var admin = new SystemUser { Account = "admin", CreateTime = DateTime.Now, CreatorId = 0, IsSuper = true, Name = "Administrator", Password = "123456".GetMd5() };
            var bll = new SystemUserBll();
            if (bll.Exists("Account='admin' OR IsSuper=1"))
            {
                MessageBox.Show("管理员账号已存在(:=");
                return;
            }

            var success = bll.Insert(admin).Id > 0;
            if (success)
            {
                MessageBox.Show(@"管理员账号添加成功");
            }
        }
    }
}
