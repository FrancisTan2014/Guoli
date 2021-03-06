﻿using Guoli.DataMigration;
using Guoli.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Guoli.Bll;
using Guoli.Utilities.Extensions;
using Application = System.Windows.Forms.Application;
using Guoli.Utilities.Helpers;
using System.IO;
using System.Collections.Concurrent;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
            using (var ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var dir = ofd.SelectedPath;
                    var fileList = Directory.GetFiles(dir).Where(IsExcel);
                    foreach (var filename in fileList)
                    {
                        TimeTableImporter.Execute(filename);
                    }

                    MessageBox.Show(@"导入成功！");
                }
            }
        }

        private bool IsExcel(string filename)
        {
            var ext = Path.GetExtension(filename)?.ToLower();
            return ext == ".xls" || ext == ".xlsx";
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
                    ImportHelper.ClearBaseData();
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
            var word = new Aspose.Words.Document();
        }

        private void Word2Html()
        {
            try
            {
                FileHelper.Word2Html("E:\\test.docx", "E:\\www");
                MessageBox.Show("转换成功(:=");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmImport_FormClosed(object sender, FormClosedEventArgs e)
        {
            ClearQueue();
            Application.Exit();
        }

        /// <summary>
        /// 使用百度分词工具将文本分词得到最后结果
        /// </summary>
        private void btnBaiduAnalysiser_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                var path = fbd.SelectedPath;
                System.Threading.Tasks.Task.Factory.StartNew(() => GetKeywordsFromFiles(path));
            }
        }

        private void GetKeywordsFromFiles(string path)
        {
            var dirs = Directory.GetDirectories(path);
            foreach (var dir in dirs)
            {
                System.Threading.Tasks.Task.Factory.StartNew(() => GetKeywordsFromFiles(dir));
            }

            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var fileExts = new string[] { ".doc", ".docx", ".txt", ".pdf" };
                var ext = Path.GetExtension(file).ToLower();
                if (fileExts.Contains(ext))
                {
                    try
                    {
                        System.Threading.Tasks.Task.Factory.StartNew(() => GetKeywordsFromNet(file));
                    }
                    catch (Exception ex)
                    {
                        // continue
                    }
                }
            }
        }

        private void GetKeywordsFromNet(string filename)
        {
            var text = "";
            var ext = Path.GetExtension(filename).ToLower();
            if (ext == ".pdf")
            {
                // text = FileHelper.GetTextFromPdf(filename);
            }
            else if (ext == ".txt")
            {
                text = FileHelper.GetTextFromTxt(filename);
            }
            else
            {
                text = FileHelper.GetTextFromWord(filename);
            }

            if (!string.IsNullOrEmpty(text))
            {
                var keywords = GetKeywordsFrom78901Net(text);
                AddKeywordsToQueye(keywords);
            }
        }

        private object _lockObj = new object();
        private void AddKeywordsToQueye(List<string> keywords)
        {
            keywords.ForEach(w => _keywodsQueue.Enqueue(w));
            if (_keywodsQueue.Count > 10000)
            {
                lock (_lockObj)
                {
                    ClearQueue();
                }
            }
        }

        private void ClearQueue()
        {
            var list = _keywodsQueue.ToList();
            KeywordsPersistence(list);
            _keywodsQueue = new ConcurrentQueue<string>();
            GC.Collect();
        }

        private ConcurrentQueue<string> _keywodsQueue = new ConcurrentQueue<string>();
        /// <summary>
        /// 将获得的关键字持久化
        /// </summary>
        /// <param name="keywords"></param>
        private void KeywordsPersistence(List<string> keywords)
        {
            var list = keywords.Distinct();

            var keywordsBll = new TraficKeywordsBll();
            var modelList = new List<TraficKeywords>();
            foreach (var word in list)
            {
                modelList.Add(new TraficKeywords { Keywords = word, AddTime = DateTime.Now });
            }

            keywordsBll.BulkInsert(modelList);
        }

        /// <summary>
        /// 从 http://www.78901.net/participle/?ac=done 上获取中文分词结果
        /// </summary>
        private List<string> GetKeywordsFrom78901Net(string text)
        {
            var url = "http://www.78901.net/participle/?ac=done";
            var postData = $"do_fork=1&do_unit=1&do_multi=1&do_prop=1&pri_dict=1&Submit=分词&source={text}";
            var postBytes = Encoding.UTF8.GetBytes(postData);

            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
            client.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Safari/537.36");

            var response = client.UploadData(url, "POST", postBytes);
            var resHtml = Encoding.UTF8.GetString(response);

            var match = Regex.Match(resHtml, @"<font\s+color='blue'>自动识别词[^<]+</font>([^<]+)<br\s*/>");
            if (match.Success)
            {
                var words = match.Groups[1].Value;
                words = Regex.Replace(words, @"/[a-z]+,\s*", "|");
                return words.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }

            return new List<string>();
        }

        /// <summary>
        /// 去除重复的关键字（单独处理 TraficKeywords 表）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistinct_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定要清除 TraficKeywods 表中的重复项吗？", "警告", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                var bll = new TraficKeywordsBll();
                var list = bll.QueryAll().Distinct();

                var removed = new List<string>();
                var newList = new List<TraficKeywords>();
                foreach (var item in list)
                {
                    if (!Regex.IsMatch(item.Keywords, "\\d"))
                    {
                        newList.Add(new TraficKeywords { Keywords = item.Keywords });
                    }
                    else
                    {
                        removed.Add(item.Keywords);
                    }
                }

                bll.ExecuteSql("TRUNCATE TABLE TraficKeywords;");
                bll.BulkInsert(newList);

                using (var fs = new FileStream("E:\\removed.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (var writer = new StreamWriter(fs))
                    {
                        writer.Write(string.Join("\r\n", removed));
                    }
                }
            }
        }

        /// <summary>
        /// 处理由重复的关键字引起的重复搜索结果
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDistinct2_Click(object sender, EventArgs e)
        {
            var bll = new TraficKeywordsBll();
            var resBll = new TraficSearchResultBll();
            var dbUpdateBll = new DbUpdateLogBll();

            var list = bll.QueryAll();
            var searchResults = resBll.QueryList("", new string[] { "Id", "KeywordsId" });
            var groups = list.GroupBy(k => k.Keywords);
            foreach (var group in groups)
            {
                if (group.Count() > 1)
                {
                    var ids = group.Select(k => k.Id).ToList();
                    var firstId = ids.First();
                    ids.RemoveAt(0);

                    // 删除重复项
                    var idsStr = string.Join(",", ids);
                    var deleteKeywodsSql = $"DELETE FROM TraficKeywords WHERE Id IN({idsStr})";
                    var deleteKeywordsUpdates = $"DELETE FROM DbUpdateLog WHERE TargetId IN({idsStr}) AND TableName='TraficKeywords'";

                    var results = searchResults.Where(r => ids.Contains(r.KeywordsId));
                    var resIds = results.Select(r => r.Id);
                    var resIdsStr = string.Join(",", resIds);
                    var deleteResultSql = $"DELETE FROM TraficSearchResult WHERE KeywordsId IN({idsStr})";
                    var deleteResultUpdates = $"DELETE FROM DbUpdateLog WHERE TargetId IN({(resIdsStr == "" ? "0" : resIdsStr)}) AND TableName='TraficSearchResult'";

                    bll.ExecuteTransation(
                        () => bll.ExecuteSql(deleteKeywodsSql) >= 0,
                        () => bll.ExecuteSql(deleteKeywordsUpdates) >= 0,
                        () => bll.ExecuteSql(deleteResultSql) >= 0,
                        () => bll.ExecuteSql(deleteResultUpdates) >= 0
                    );
                }
            }
        }

        private void btnImportStaff_Click(object sender, EventArgs e)
        {
            using (var ofd = new FolderBrowserDialog())
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var dir = ofd.SelectedPath;
                    var fileList = Directory.GetFiles(dir).Where(IsExcel);
                    var importer = new StaffImporter();

                    pb.Maximum = fileList.Count();
                    pb.Visible = true;
                    pb.Value = 0;
                    foreach (var filename in fileList)
                    {
                        importer.Execute(filename);
                        pb.Value += 1;
                    }

                    pb.Visible = false;
                    MessageBox.Show(@"导入成功！");
                }
            }
        }
    }
}
