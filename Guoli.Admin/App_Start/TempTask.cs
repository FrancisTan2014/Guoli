using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace Guoli.Admin
{
    /// <summary>
    /// 管理在程序启动时运行的临时任务
    /// </summary>
    /// <author>Francis Tan</author>
    /// <since>2017-02-08</since>
    public class TempTask
    {
        /// <summary>
        /// 开启新线程执行临时任务
        /// </summary>
        public static void RunTempTasks()
        {
            Task.Factory.StartNew(() =>
            {
                AddSearchKeywords();
            });
        }

        /// <summary>
        /// 添加搜索关键字，此任务仅在数据库中关键字条目数少于100个时才会执行
        /// </summary>
        public static void AddSearchKeywords()
        {
            // 判断数据库中关键字个数
            var keywordsBll = new TraficKeywordsBll();
            var totalCount = keywordsBll.GetTotalCount();
            if (totalCount < 100)
            {
                // 读取文件中的关键字列表
                var filePath = PathExtension.MapPath(AppSettings.KeywordsFilePath);
                try
                {
                    using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var streamReader = new StreamReader(fileStream))
                        {
                            var text = streamReader.ReadToEnd();
                            var keywords = text.Split(new[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                            // @FrancisTan 2017-10-27
                            // 批量插入关键字
                            var modelList = keywords.Select(k => new TraficKeywords { Keywords = k, AddTime = DateTime.Now });
                            keywordsBll.BulkInsert(modelList);
                            DataUpdateLog.BulkUpdate(nameof(TraficKeywords), 0);

                            // 依次对单个文件执行关键字搜索
                            var fileBll = new TraficFilesBll();
                            var idList = fileBll.QueryList("", new string[] { "Id" }).Select(t => t.Id).ToList();
                            idList.ForEach(id =>
                            {
                                SearchHelper.AddSearchTask(1, id);
                            });

                            //// 逐条插入数据库关执行文件的搜索任务
                            //foreach (var word in keywords)
                            //{
                            //    var condition = $"Keywords='{word}'";
                            //    if (!keywordsBll.Exists(condition))
                            //    {
                            //        var keywordsModel = new TraficKeywords { Keywords = word };
                            //        if (keywordsBll.Insert(keywordsModel).Id > 0)
                            //        {
                            //            DataUpdateLog.SingleUpdate(nameof(TraficKeywords), keywordsModel.Id, DataUpdateType.Insert);
                            //            SearchHelper.AddSearchTask(2, keywordsModel.Id);
                            //        }
                            //    }

                            //} // end foreach

                        } // end streamreader

                    } // end filestream
                }
                catch (Exception ex)
                {
                    ExceptionLogBll.ExceptionPersistence(nameof(TempTask), nameof(TempTask), ex);
                }
            }
            else
            {
                // Ignore
            }
        }
    }
}