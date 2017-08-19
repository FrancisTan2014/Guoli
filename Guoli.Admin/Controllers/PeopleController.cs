using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guoli.Admin.Models;
using Guoli.Admin.Utilities;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Helpers;
using Guoli.Utilities.Extensions;

namespace Guoli.Admin.Controllers
{
    public class PeopleController : Controller
    {
        //
        // GET: /People/

        #region 人员管理
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetPersons()
        {
            var json = JqueryDataTableAjaxHelper.GetPageListJson(
                Request,
                (pageIndex, pageSize) =>
                {
                    var viewBll = new ViewPersonInfoBll();

                    int totalCount;
                    var list = viewBll.QueryPageList(pageIndex, pageSize, "UpdateTime", true, out totalCount);

                    return new KeyValuePair<int, object>(totalCount, list);
                });

            return Json(json);
        }

        public ActionResult PersonEdit(int? id)
        {
            ViewBag.Id = id;

            return View();
        }

        [HttpPost]
        public JsonResult PersonEdit(PersonInfo person)
        {
            if (person == null)
            {
                return Json(ErrorModel.InputError);
            }

            var personBll = new PersonInfoBll();
            // 验证工号重复性
            var condition = person.Id > 0
                ? $"WorkNo='{person.WorkNo}' AND Id<>{person.Id} AND IsDelete=0"
                : $"WorkNo='{person.WorkNo}' AND IsDelete=0";
            if (personBll.Exists(condition))
            {
                return Json(ErrorModel.ExistSameItem);
            }

            // 获取姓名的简拼
            person.Spell = PinyinHelper.GetInitials(person.Name).ToLower();
            person.UpdateTime = DateTime.Now;

            var dbUpdateType = person.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;

            var success = false;
            if (person.Id > 0)
            {
                success = personBll.Update(person);
            }
            else
            {
                // 第一次录入时将密码设置为工号后四位
                var password = person.WorkNo.Substring(person.WorkNo.Length - 4);
                // person.Password = password.GetMd5();
                // @FrancisTan 修改于 2017-02-17 
                // 目的是为了统一密码的生成，保证一致性
                person.Password = EncryptHelper.EncryptPassword(password);

                success = personBll.Insert(person).Id > 0;
            }

            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof (PersonInfo).Name, (int)person.Id, dbUpdateType);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult GetPersonInfo(int id)
        {
            var personInfoBll = new PersonInfoBll();
            var person = personInfoBll.QuerySingle("IsDelete=0 AND Id=" + id);

            if (person == null)
            {
                return Json(ErrorModel.GetDataFailed);
            }

            return Json(ErrorModel.GetDataSuccess(person));
        }

        [HttpPost]
        public JsonResult AddPostion(string postName)
        {
            postName = postName.Trim();

            if (string.IsNullOrEmpty(postName))
            {
                return Json(ErrorModel.InputError);
            }

            var posts = new Posts
            {
                PostName = postName
            };

            var postBll = new PostsBll();
            var condition = string.Format("IsDelete=0 AND PostName='{0}'", postName);
            if (postBll.Exists(condition))
            {
                return Json(ErrorModel.ExistSameItem);
            }

            postBll.Insert(posts);

            if (posts.Id > 0)
            {
                DataUpdateLog.SingleUpdate(typeof(Posts).Name, posts.Id, DataUpdateType.Insert);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }
        
        #endregion

        #region 部门管理
        public ActionResult Departs()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddDepart()
        {
            var departJson = Request["depart"];
            var depart = JsonHelper.Deserialize<DepartInfo>(departJson);

            var departBll = new DepartInfoBll();
            var success = departBll.Insert(depart).Id > 0;
            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(DepartInfo).Name, depart.Id, DataUpdateType.Insert);

                return Json(ErrorModel.AddDataSuccess(depart.Id));
            }

            return Json(ErrorModel.OperateFailed);
        }

        [HttpPost]
        public JsonResult AddOrUpdateDepart(DepartInfo depart)
        {
            if (depart != null)
            {
                var bll = new DepartInfoBll();
                if (bll.Exists($"DepartmentName='{depart.DepartmentName}' AND IsDelete=0"))
                {
                    return Json(ErrorModel.ExistSameItem);
                }

                var updateType = depart.Id > 0 ? DataUpdateType.Update : DataUpdateType.Insert;
                var success = bll.ExecuteTransation(
                    () => depart.Id == 0 ? bll.Insert(depart).Id > 0 : bll.Update(depart),
                    () => DataUpdateLog.SingleUpdate(nameof(DepartInfo), depart.Id, updateType)
                );

                return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
            }

            return Json(ErrorModel.InputError);
        }

        [HttpPost]
        public JsonResult DeleteDepart(int id)
        {
            var personBll = new PersonInfoBll();
            var personCount = personBll.CountDepartPerson(id);
            if (personCount > 0)
            {
                return Json(ErrorModel.DeleteForbidden);
            }

            var departBll = new DepartInfoBll();
            var subDeparts = departBll.QueryList("IsDelete=0 AND ParentId=" + id);
            if (subDeparts.Any())
            {
                return Json(ErrorModel.DeleteForbidden);
            }

            var success = departBll.DeleteSoftly(id);
            if (success)
            {
                DataUpdateLog.SingleUpdate(typeof(DepartInfo).Name, id, DataUpdateType.Delete);

                return Json(ErrorModel.OperateSuccess);
            }

            return Json(ErrorModel.OperateFailed);
        }
        #endregion

        #region 职务管理

        [HttpPost]
        public JsonResult AddOrUpdatePost(Posts model)
        {
            if (model != null)
            {
                var bll = new PostsBll();
                if (bll.Exists($"PostName='{model.PostName}' AND IsDelete=0"))
                {
                    return Json(ErrorModel.ExistSameItem);
                }

                var isUpdate = model.Id > 0;
                var updateType = isUpdate ? DataUpdateType.Update : DataUpdateType.Insert;
                var success = bll.ExecuteTransation(
                    () => isUpdate ? bll.Update(model) : bll.Insert(model).Id > 0,
                    () => DataUpdateLog.SingleUpdate(nameof(Posts), model.Id, updateType)
                );

                return Json(success ? ErrorModel.OperateSuccess : ErrorModel.OperateFailed);
            }

            return Json(ErrorModel.InputError);
        }

        #endregion
    }
}
