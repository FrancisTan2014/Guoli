using Guoli.Admin.Models;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// Npoi帮助类，统一管理系统中所有操作excel文件的逻辑
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-08-13</since>
    public static class NpoiHelper
    {
        #region 考试试题上传
        /// <summary>
        /// 对上传的试题题库进行分析
        /// </summary>
        /// <param name="workBook"></param>
        /// <returns></returns>
        public static object AnalysisExamQuestion(ExamFiles examFiles)
        {
            var absolutePath = HttpContext.Current.Server.MapPath(examFiles.FilePath);
            try
            {
                using (var fileStream = new FileStream(absolutePath, FileMode.Open, FileAccess.Read))
                {
                    var workBook = new HSSFWorkbook(fileStream);
                    var qaList = AnalysisQuestions(workBook);

                    if (qaList.Count == 0)
                    {
                        return ErrorModel.OperateFailed;
                    }

                    return InsertQuestionsToDb(examFiles, qaList);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogBll.ExceptionPersistence("ExamController.cs", "ExamController", ex);

                return ErrorModel.OperateFailed;
            }
        }

        /// <summary>
        /// 按照特定的格式解析上传的excel文件，返回问题为键，答案为值的键值对集合
        /// </summary>
        private static List<KeyValuePair<ExamQuestion, List<ExamAnswers>>> AnalysisQuestions(HSSFWorkbook workBook)
        {
            var list = new List<KeyValuePair<ExamQuestion, List<ExamAnswers>>>();
            foreach (ISheet sheet in workBook)
            {
                var rows = sheet.GetRowEnumerator();
                while (rows.MoveNext())
                {
                    var row = (HSSFRow)rows.Current;
                    if (IsLegalRow(row))
                    {
                        var question = GetQuestion(row);
                        var answers = GetAnswers(row);
                        var keyPair = new KeyValuePair<ExamQuestion, List<ExamAnswers>>
                        (
                            question,
                            answers
                        );

                        list.Add(keyPair);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// 对excel的单行进行格式验证
        /// </summary>
        private static bool IsLegalRow(HSSFRow row)
        {
            if (row.Cells.Count < 8)
            {
                return false;
            }

            // 第一个单元格：题号必须是数字
            var number = row.Cells[0].ToString().ToInt32();
            if (number == 0)
            {
                return false;
            }

            // 第二个单元格：问题内容，不能为空
            var question = row.Cells[1].ToString();
            if (string.IsNullOrEmpty(question))
            {
                return false;
            }

            // 第三个单元格：题目类型必须是1-3之内的数字
            var type = row.Cells[2].ToString().ToInt32();
            if (type < 1 || type > 3)
            {
                return false;
            }

            // 第四五六七单元格：答案，至少有两个不为空
            var emptyCount = 0;
            for (int i = 3; i < 7; i++)
            {
                var temp = row.Cells[i].ToString();
                if (string.IsNullOrWhiteSpace(temp))
                {
                    emptyCount++;
                }
            }

            if (emptyCount > 2)
            {
                return false;
            }

            // 第八个单元格：答案，必须能转换为数字
            var answer = row.Cells[7].ToString().ToInt32();
            if (answer == 0)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 从单行中获取问题内容
        /// </summary>
        private static ExamQuestion GetQuestion(HSSFRow row)
        {
            return new ExamQuestion
            {
                AnswerType = row.Cells[2].ToString().ToInt32(),
                Question = row.Cells[1].ToString()
            };
        }

        /// <summary>
        /// 从单行中获取答案列表
        /// </summary>
        private static List<ExamAnswers> GetAnswers(HSSFRow row)
        {
            var list = new List<ExamAnswers>();

            var rightAnswer = row.Cells[7].ToString();
            var answerCount = 0;
            for (int i = 3; i < 7; i++)
            {
                var answer = row.Cells[i].ToString();
                if (!string.IsNullOrWhiteSpace(answer))
                {
                    answerCount++;
                    var isRight = rightAnswer.Contains(answerCount.ToString());

                    list.Add(new ExamAnswers
                    {
                        Answer = answer,
                        IsRight = isRight
                    });
                }
            }

            return list;
        }

        /// <summary>
        /// 将试题文件及问题集合插入数据库中
        /// </summary>
        private static object InsertQuestionsToDb(ExamFiles examFiles, List<KeyValuePair<ExamQuestion, List<ExamAnswers>>> list)
        {
            var examFilesBll = new ExamFilesBll();
            examFilesBll.Insert(examFiles);

            if (examFiles.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(ExamFiles).Name, examFiles.Id, DataUpdateType.Insert);

                var questionBll = new ExamQuestionBll();
                var answerBll = new ExamAnswersBll();

                // 在插入之前获取两表的最大id，以便在插入完成之后做数据库更新记录
                var maxQuestionId = (int)questionBll.GetMaxId();
                var maxAnswerId = (int)answerBll.GetMaxId();

                foreach (var keyPair in list)
                {
                    var question = keyPair.Key;
                    var answers = keyPair.Value;
                    question.ExamFileId = examFiles.Id;

                    // 将问题与答案放到事务中一起插入，保证数据的准确性
                    questionBll.ExecuteTransation(() => {                        
                        questionBll.Insert(question);
                        if (question.Id > 0)
                        {
                            answers.ForEach(answer => answer.QuestionId = question.Id);
                            answerBll.BulkInsert(answers);

                            return true;
                        }

                        return false;
                    });
                }

                // 数据库更新记录上传
                DataUpdateLog.BulkUpdate(typeof(ExamQuestion).Name, maxQuestionId, DataUpdateType.Insert);
                DataUpdateLog.BulkUpdate(typeof(ExamAnswers).Name, maxAnswerId, DataUpdateType.Insert);

                return ErrorModel.OperateSuccess;
            }

            return ErrorModel.OperateFailed;
        } 
        #endregion
    }
}