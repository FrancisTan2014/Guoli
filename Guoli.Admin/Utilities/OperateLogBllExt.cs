using Guoli.Bll;
using Guoli.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// 为OperateLogBll增加扩展方法
    /// 因为会用到在本项目中定义的枚举
    /// 为了不让Bll层引用本项目
    /// 因此给它添加扩展方法是最好的选择
    /// </summary>
    public static class OperateLogBllExt
    {
        public static bool Add(this OperateLogBll value, string table, int targetId, DataUpdateType operateType, int systemUserId, string log)
        {
            var userBll = new SystemUserBll();
            var user = userBll.QuerySingle(systemUserId);
            log = $"[姓名：{user.Name}][账号：{user.Account}] {log}";

            var model = new OperateLog
            {
                TargetTable = table,
                TargetId = targetId,
                OperateType = (int)operateType,
                SystemUserId = systemUserId,
                LogContent = log,
                OperateTime = DateTime.Now
            };

            return value.Insert(model).Id > 0;
        }
    }
}