using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Guoli.Utilities.Enums;

namespace Guoli.Admin.Models
{
    /// <summary>
    /// 封装了公共api接口所需的参数
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-28</since>
    public class CommonApiModel
    {
        /// <summary>
        /// 数据库表名称
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string TableName { get; set; }

        /// <summary>
        /// 所要操作的字段名称数组
        /// </summary>
        public string[] Fields { get; set; }

        /// <summary>
        /// 标识对数据库的操作类型的枚举值
        /// </summary>
        public DbOperateType Operate { get; set; }

        /// <summary>
        /// 分页查询的页码
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageIndex { get; set; }

        /// <summary>
        /// 分页查询的数据条数
        /// </summary>
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }

        /// <summary>
        /// 本次查询的起始Id（大于不等于）
        /// </summary>
        public int StartId { get; set; }

        /// <summary>
        /// 查询或者更新数据的条件
        /// </summary>
        public string Condition { get; set; }

        /// <summary>
        /// 查询数据时排序的字段
        /// </summary>
        public string OrderField { get; set; }

        /// <summary>
        /// 表示是否需要对结果集进行降序排序
        /// </summary>
        public bool IsDescending { get; set; }

        /// <summary>
        /// app传给服务器的数据集
        /// </summary>
        public string Data { get; set; }
    }
}