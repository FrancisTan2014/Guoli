using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Guoli.Import
{
    public sealed class StaffImporter
    {
        public StaffImporter()
        {

        }

        public void Execute(string filename)
        {
            using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                IWorkbook workBook;
                try
                {
                    // excel 2003 及以下版本
                    workBook = new HSSFWorkbook(fs);
                }
                catch
                {
                    // excel 2007 及以上版本
                    workBook = new XSSFWorkbook(fs);
                }

                foreach (ISheet sheet in workBook)
                {
                    try
                    {
                        if (IsStyleValid(sheet))
                        {
                            var tuple = Extract(sheet);
                            var posts = tuple.Item1;
                            var departs = tuple.Item2;
                            var staff = tuple.Item3;

                            Uniq(ref posts, ref departs, ref staff);
                            Persistent(posts, departs, staff);
                        }
                    }
                    catch (Exception ex)
                    {
                        var log = new ExceptionLog();
                        log.FileName = nameof(StaffImporter);
                        log.ClassName = nameof(StaffImporter);
                        log.MethodName = nameof(Execute);
                        log.Instance = ex.Source;
                        log.Message = ex.Message;
                        log.StackTrace = ex.StackTrace;
                        log.HappenTime = DateTime.Now;
                        new ExceptionLogBll().Insert(log);
                    }
                }
            }
        }

        private void Uniq(ref List<Posts> posts, ref List<DepartInfo> departs, ref List<PersonInfo> staff)
        {
            List<Posts> _posts = new PostsBll().QueryAll().ToList();
            List<DepartInfo> _departs = new DepartInfoBll().QueryAll().ToList();
            List<string> _workNos = new PersonInfoBll()
                .QueryList("IsDelete=0", new[] { nameof(PersonInfo.WorkNo) })
                .Select(p => p.WorkNo).ToList();

            posts = Distinct(posts, p => p.PostName).Where(p => p.PostName != string.Empty).ToList();
            departs = Distinct(departs, d => d.DepartmentName).Where(d => d.DepartmentName != string.Empty).ToList();

            posts = posts.Where(p => !Contains(_posts, item => item.PostName == p.PostName)).ToList();
            departs = departs.Where(d => !Contains(_departs, item => item.DepartmentName == d.DepartmentName)).ToList();
            staff = staff.Where(s => !_workNos.Contains(s.WorkNo)).ToList();
        }

        private bool Contains<T>(List<T> list, Func<T, bool> predicate)
        {
            foreach (T item in list)
            {
                if (predicate(item))
                {
                    return true;
                }
            }
            return false;
        }

        private List<T> Distinct<T, TKey>(IEnumerable<T> list, Func<T, TKey> field)
        {
            var groups = list.GroupBy(field);
            var result = new List<T>();
            foreach (IGrouping<TKey, T> g in groups)
            {
                result.Add(g.First());
            }
            return result;
        }

        /// <summary>
        /// 工号	姓名	拼音	职务	状态	部门	文化程度	政治面貌	住宅电话	手机号 办公室电话 籍贯 民族
        /// </summary>
        /// <param name="sheet"></param>
        /// <returns></returns>
        private bool IsStyleValid(ISheet sheet)
        {
            var firstRow = sheet.GetRow(0);
            if (firstRow.LastCellNum < 12)
            {
                return false;
            }

            var txt = firstRow.Cells[0].StringCellValue.Trim();
            if (!txt.Contains("工号"))
            {
                return false;
            }

            txt = firstRow.Cells[1].StringCellValue.Trim();
            if (!txt.Contains("姓名"))
            {
                return false;
            }

            txt = firstRow.Cells[3].StringCellValue.Trim();
            if (!txt.Contains("职务"))
            {
                return false;
            }

            txt = firstRow.Cells[5].StringCellValue.Trim();
            if (!txt.Contains("部门"))
            {
                return false;
            }

            return true;
        }

        private Tuple<List<Posts>, List<DepartInfo>, List<PersonInfo>> Extract(ISheet sheet)
        {
            var posts = new List<Posts>();
            var departs = new List<DepartInfo>();
            var staff = new List<PersonInfo>();
            for (var i = 1; i < sheet.LastRowNum; i++)
            {
                try
                {
                    var row = sheet.GetRow(i);
                    var tuple = GetInstances(row);
                    posts.Add(tuple.Item1);
                    departs.Add(tuple.Item2);
                    staff.Add(tuple.Item3);
                }
                catch (Exception ex)
                {
                    var log = new ExceptionLog();
                    log.FileName = nameof(StaffImporter);
                    log.ClassName = nameof(StaffImporter);
                    log.MethodName = nameof(Extract);
                    log.Instance = ex.Source;
                    log.Message = ex.Message;
                    log.StackTrace = ex.StackTrace;
                    log.HappenTime = DateTime.Now;
                    new ExceptionLogBll().Insert(log);
                }
            }

            return new Tuple<List<Posts>, List<DepartInfo>, List<PersonInfo>>(posts, departs, staff);
        }

        private Tuple<Posts, DepartInfo, PersonInfo> GetInstances(IRow row)
        {
            var postName = row.Cells[3].StringCellValue.Trim();
            var post = new Posts { PostName = postName };

            var departmentName = row.Cells[5].StringCellValue.Trim();
            var depart = new DepartInfo { DepartmentName = departmentName };

            var workNo = row.Cells[0].StringCellValue.Trim();
            var index = workNo.Length > 5 ? workNo.Length - 5 : 0;
            var pwd = workNo.Substring(index);
            var person = new PersonInfo
            {
                WorkNo = workNo,
                Name = row.Cells[1].StringCellValue.Trim(),
                Spell = row.Cells[2].StringCellValue.Trim(),
                Password = EncryptHelper.EncryptPassword(pwd),
                PersonId = departmentName, // 此处用 PersonId 字段暂时存储部门名称
                PhotoPath = postName, // 此处用 PhotoPath 字段暂时存储职务名称
                BirthDate = new DateTime(1970, 1, 1),
            };

            return new Tuple<Posts, DepartInfo, PersonInfo>(post, depart, person);
        }

        private void Persistent(List<Posts> posts, List<DepartInfo> departs, List<PersonInfo> staff)
        {
            var staffBll = new PersonInfoBll();
            var dbUpdateBll = new DbUpdateLogBll();
            Func<bool>[] delegates = new Func<bool>[3];
            delegates[0] = () =>
            {
                if (posts.Count > 0)
                {
                    var postBll = new PostsBll();
                    var maxId = postBll.GetMaxId();
                    postBll.BulkInsert(posts);

                    var ids = postBll.QueryList("Id>" + maxId, new[] { nameof(Posts.Id) }).Select(p => p.Id);
                    var dbLogs = ids.Select(id => new DbUpdateLog { TableName = nameof(Posts), TargetId = id, UpdateType = 1, UpdateTime = DateTime.Now });
                    dbUpdateBll.BulkInsert(dbLogs);
                }
                return true;
            };
            delegates[1] = () =>
            {
                if (departs.Count > 0)
                {
                    var departBll = new DepartInfoBll();
                    var maxId = departBll.GetMaxId();
                    departBll.BulkInsert(departs);

                    var ids = departBll.QueryList("Id>" + maxId, new[] { nameof(DepartInfo.Id) }).Select(p => p.Id);
                    var dbLogs = ids.Select(id => new DbUpdateLog { TableName = nameof(DepartInfo), TargetId = id, UpdateType = 1, UpdateTime = DateTime.Now });
                    dbUpdateBll.BulkInsert(dbLogs);
                }
                return true;
            };
            delegates[2] = () =>
            {
                List<Posts> _posts = new PostsBll().QueryAll().ToList();
                List<DepartInfo> _departs = new DepartInfoBll().QueryAll().ToList();
                staff.ForEach(s =>
                {
                    // 根据前面用 PersonId 存储的部门名称找到此员工对应的部门
                    // 根据前面用 PhotoPath 存储的职务名称找到此员工对应的职务
                    var depart = _departs.Find(d => d.DepartmentName == s.PersonId);
                    var post = _posts.Find(p => p.PostName == s.PhotoPath);
                    s.DepartmentId = depart?.Id ?? 0;
                    s.PostId = post?.Id ?? 0;
                    s.PersonId = string.Empty;
                    s.PhotoPath = string.Empty;
                });

                var maxId = staffBll.GetMaxId();
                staffBll.BulkInsert(staff);

                var ids = staffBll.QueryList("Id>" + maxId, new[] { nameof(PersonInfo.Id) }).Select(p => p.Id);
                var dbLogs = ids.Select(id => new DbUpdateLog { TableName = nameof(PersonInfo), TargetId = (int)id, UpdateType = 1, UpdateTime = DateTime.Now });
                dbUpdateBll.BulkInsert(dbLogs);

                return true;
            };

            // 若插入失败，则尝试五次
            for (var i = 0; i < 5; i++)
            {
                var success = staffBll.ExecuteTransation(delegates);
                if (success)
                {
                    return;
                }
            }
        }
    }
}
