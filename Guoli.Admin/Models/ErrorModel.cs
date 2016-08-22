using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Guoli.Model;

namespace Guoli.Admin.Models
{
    /// <summary>
    /// 封装针对异步请求返回的错误消息
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-14</since>
    public class ErrorModel
    {
        /// <summary>
        /// 操作成功
        /// </summary>
        public static object OperateSuccess
        {
            get
            {
                return new
                {
                    code = 100,
                    msg = "操作成功"
                };
            }
        }
        
        /// <summary>
        /// 输入有误
        /// </summary>
        public static object InputError
        {
            get
            {
                return new
                {
                    code = 101,
                    msg = "输入参数有误"
                };
            }
        }

        public static object LoginSuccess
        {
            get
            {
                return new
                {
                    code = 102,
                    msg = "登录成功"
                };
            }
        }

        /// <summary>
        /// 登录失败
        /// </summary>
        public static object LoginFailed
        {
            get
            {
                return new
                {
                    code = 103,
                    msg = "用户名或者密码错误"
                };
            }
        }

        /// <summary>
        /// 已退出登录
        /// </summary>
        public static object Logout
        {
            get
            {
                return new
                {
                    code = 105,
                    msg = "已退出登录"
                };
            }
        }

        /// <summary>
        /// 获取封装了通知客户端需要跳转到登录页的消息
        /// </summary>
        /// <param name="backUrl">在登录页面登录成功后跳转至的页面地址</param>
        /// <returns>返回给客户端的json数据</returns>
        public static object NeedLoginFirst(string backUrl)
        {
            return new
            {
                code = 104,
                msg = "未登录或者登录已失效",
                backUrl
            };
        }

        /// <summary>
        /// 非法的app签名
        /// </summary>
        public static object SignatureError
        {
            get
            {
                return new
                {
                    code = 106,
                    msg = "非法的app签名"
                };
            }
        }

        /// <summary>
        /// 批量插入数据成功
        /// </summary>
        public static object BulkInsertSuccess
        {
            get
            {
                return new
                {
                    code = 107, 
                    msg = "数据插入成功"
                };
            }
        }

        /// <summary>
        /// app请求数据成功后返回的消息（带有请求到的数据）
        /// </summary>
        /// <param name="data">请求到的数据结果</param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static object GetDataSuccess(object data, string tableName = "")
        {
            return new
            {
                code = 108,
                msg = "数据请求成功",
                data = data,
                tableName = tableName
            };
        }

        /// <summary>
        /// 未查询到指定信息
        /// </summary>
        public static object GetDataFailed
        {
            get
            {
                return new
                {
                    code = 109, 
                    msg = "未能查询到指定信息"
                };
            }
        }

        /// <summary>
        /// 文件上传失败
        /// </summary>
        public static object FileUploadFailed
        {
            get
            {
                return new
                {
                    code = 110,
                    msg = "文件上传失败"
                };
            }
        }
        
        /// <summary>
        /// 操作失败
        /// </summary>
        public static object OperateFailed
        {
            get
            {
                return new
                {
                    code = 111,
                    msg = "操作失败，请稍后重试"
                };
            }
        }

        /// <summary>
        /// 结果为真（针对某些需要从服务器获取一段逻辑的真假的返回结果）
        /// </summary>
        public static object TrueResult
        {
            get
            {
                return new
                {
                    code = 112,
                    msg = "结果为是"
                };
            }
        }

        /// <summary>
        /// 结果为假（针对某些需要从服务器获取一段逻辑的真假的返回结果）
        /// </summary>
        public static object FalseResult
        {
            get
            {
                return new
                {
                    code = 113,
                    msg = "结果为否"
                };
            }
        }

        /// <summary>
        /// 存在依赖项
        /// </summary>
        public static object DeleteForbidden
        {
            get
            {
                return new
                {
                    code = 114,
                    msg = "存在依赖项，无法删除"
                };
            }
        }

        /// <summary>
        /// 添加数据成功
        /// </summary>
        /// <param name="id">新添加的数据id</param>
        /// <returns></returns>
        public static object AddDataSuccess(int id)
        {
            return new
            {
                code = 116,
                msg = "添加成功",
                id
            };
        }

        /// <summary>
        /// 未指定上传的文件类型
        /// </summary>
        public static object UnknownUploadFileType
        {
            get
            {
                return new
                {
                    code = 117,
                    msg = "未指定上传的文件类型"
                };
            }
        }

        /// <summary>
        /// 已存在相同项
        /// </summary>
        public static object ExistSameItem
        {
            get
            {
                return new
                {
                    code = 118,
                    msg = "已存在相同顶"
                };
            }
        }
    }
}