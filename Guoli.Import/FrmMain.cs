using Guoli.DataMigration;
using Guoli.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guoli.Bll;
using Guoli.Utilities.Extensions;
using Application = System.Windows.Forms.Application;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.Diagnostics;

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
        /// 清空基础数据（车站、线路、车次）
        /// </summary>
        private void btnClear_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(@"提示，您确定要清空基础数据吗？", @"警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (res == DialogResult.Yes)
            {
                res = MessageBox.Show(@"再次提示，您确定要清空基础数据吗？", @"警告", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Yes)
                {
                    var tables = new List<string> { "TrainMoment", "TrainNoLine", "LineStations", "BaseStation", "BaseLine", "TrainNo" };
                    var truncate = $"TRUNCATE TABLE {string.Join("; TRUNCATE TABLE ", tables)};";
                    var delete = $"DELETE FROM DbUpdateLog WHERE TableName IN( {string.Join(", ", tables.Select(s => $"'{s}'"))} );";
                    //var sql = @"TRUNCATE TABLE TrainMoment
                    //            TRUNCATE TABLE TrainNoLine
                    //            TRUNCATE TABLE LineStations
                    //            TRUNCATE TABLE BaseStation
                    //            TRUNCATE TABLE BaseLine
                    //            TRUNCATE TABLE TrainNo
                    //            DELETE FROM DbUpdateLog WHERE DELETE FROM DbUpdateLog WHERE TableName IN('')";
                    var bll = new TrainNoBll();
                    bll.ExecuteSql(truncate + delete);
                    MessageBox.Show(@"基础数据已被清空，您可以点击上方的按钮重新导入(:=");
                }
            }
        }

        /// <summary>
        /// 手动执行同步运安数据库数据的操作
        /// </summary>
        private void btnMigration_Click(object sender, EventArgs e)
        {
            var bll = new PersonInfoBll();
            if (bll.Exists())
            {
                MessageBox.Show(@"人员信息已存在(:=");
            }
            else
            {
                OracleMigrationTask.ExecuteDataSynchronization();
            }
        }

        /// <summary>
        /// 系统初次部署时，添加管理员账号
        /// </summary>
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var admin = new SystemUser { Account = "admin", CreateTime = DateTime.Now, CreatorId = 0, IsSuper = true, Name = "Administrator", Password = "123456".GetMd5() };
            var bll = new SystemUserBll();
            if (bll.Exists("IsSuper=1"))
            {
                MessageBox.Show(@"管理员账号已存在(:=");
                return;
            }

            var success = bll.Insert(admin).Id > 0;
            if (success)
            {
                MessageBox.Show(@"管理员账号添加成功");
            }
        }

        private void btnTestChangeConfig_Click(object sender, EventArgs e)
        {
            // Word2Pdf();
            Word2Html();
        }

        private void Word2Pdf()
        {
            var word = new ApplicationClass();

            Document document = null;

            try
            {
                document = word.Documents.Open("E:\\test.doc");
                document.ExportAsFixedFormat("E:\\test.pdf", WdExportFormat.wdExportFormatPDF);
                MessageBox.Show("success(:=");
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
            finally
            {
                document?.Close();
            }
        }

        private void Word2Html()
        {
            var word = new ApplicationClass();
            var doc = word.Documents.Open("E:\\test.doc", true, true);

            try
            {                
                doc.SaveAs2("E:\\test.html", WdSaveFormat.wdFormatHTML);
                MessageBox.Show("转换成功(:=");
            }
            catch (Exception ex)
            {
                // Ignore
            }
            finally
            {
                doc.Close();
                word.Quit();
            }

        }

        private void frmImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
