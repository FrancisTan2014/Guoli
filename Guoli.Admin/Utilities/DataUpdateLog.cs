using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Enums;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// 维护数据更新记录，保证APP更新数据能获取到最新的数据
    /// </summary>
    public static class DataUpdateLog
    {
        /// <summary>
        /// 数据库更新记录业务类型实体
        /// </summary>
        private static readonly DbUpdateLogBll UpdateBll = new DbUpdateLogBll();

        /// <summary>
        /// 单条记录更新
        /// </summary>
        /// <param name="tableName">目标表格名称</param>
        /// <param name="id">当前更新这条记录的主键</param>
        /// <param name="updateType">更新类型枚举</param>
        public static bool SingleUpdate(string tableName, int id, DataUpdateType updateType)
        {
            var updateModel = new DbUpdateLog
            {
                TableName = tableName,
                TargetId = id,
                UpdateType = (int)updateType,
                UpdateTime = DateTime.Now
            };

            return UpdateBll.Insert(updateModel).Id > 0;
        }

        /// <summary>
        /// 对数据的批量更新
        /// </summary>
        /// <param name="tableName">目标表格名称</param>
        /// <param name="startId">当前更新记录开始位置（不包括所传入的id）</param>
        /// <param name="updateType">更新类型枚举</param>
        public static void BulkUpdate(string tableName, int startId, DataUpdateType updateType = DataUpdateType.Insert)
        {
            var bllEntity = BllFactory.GetBllInstance(tableName);
            var bllType = bllEntity.GetType();

            try
            {
                var whereStr = "Id>" + startId;
                var idList = (IEnumerable<object>)bllType.InvokeMember("QuerySingleColumn", BindingFlags.InvokeMethod, null, bllEntity, new object[] { whereStr, "Id" });
                
                var updateModelList = idList.Select(id => new DbUpdateLog
                {
                    TableName = tableName,
                    TargetId = (int)id,
                    UpdateType = (int)updateType,
                    UpdateTime = DateTime.Now
                });

                UpdateBll.BulkInsert(updateModelList);
            }
            catch (Exception ex)
            {
                ExceptionLogBll.ExceptionPersistence("DataUpdateLog.cs", "DataUpdateLog", ex);
            }
        }

        /// <summary>
        /// 对数据的批量更新
        /// </summary>
        /// <param name="tableName">目标表格名称</param>
        /// <param name="targetIdList">目标Id集合</param>
        /// <param name="updateType">更新类型枚举</param>
        public static void BulkUpdate(string tableName, IEnumerable<int> targetIdList,
            DataUpdateType updateType = DataUpdateType.Insert)
        {
            if (string.IsNullOrEmpty(tableName))
            {
                throw new ArgumentNullException(nameof(tableName));
            }
            if (targetIdList == null)
            {
                throw new ArgumentNullException(nameof(targetIdList));
            }

            var idList = targetIdList.ToList();
            if (!idList.Any())
            {
                return;
            }

            var updateList = idList.Select(id => new DbUpdateLog
            {
                TableName = tableName,
                TargetId = id,
                UpdateType = 3,
                UpdateTime = DateTime.Now
            });

            UpdateBll.BulkInsert(updateList);
        }
    }
}