using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// 提供对appSettings中的配置项统一访问的静态属性
    /// </summary>
    /// <author>FrancisTan</author>
    /// <since>2016-07-28</since>
    public static class AppSettings
    {
        /// <summary>
        /// 指导司机职位Id
        /// </summary>
        public static readonly int InstructorPostId = ConfigurationManager.AppSettings["InstructorPostId"].ToInt32();

        /// <summary>
        /// 验证app请求签名的token
        /// </summary>
        public static readonly string AppRequestToken = ConfigurationManager.AppSettings["AppRequestToken"];

        /// <summary>
        /// 车站相关文件存储目录
        /// </summary>
        public static readonly string StationFilesPath = ConfigurationManager.AppSettings["StationFilesPath"];

        /// <summary>
        /// 人员头像照片存储目录
        /// </summary>
        public static readonly string PersonPhotos = ConfigurationManager.AppSettings["PersonPhotos"];

        /// <summary>
        /// 行车资料相关文件存放的目录
        /// </summary>
        public static readonly string DriveFiles = ConfigurationManager.AppSettings["DriveFiles"];

        public static readonly string ExamFiles = ConfigurationManager.AppSettings["ExamFiles"];

        public static readonly string AnnounceFiles = ConfigurationManager.AppSettings["AnnounceFiles"];

        /// <summary>
        /// added by @FrancisTan at 20170208 
        /// </summary>
        public static readonly string KeywordsFilePath = ConfigurationManager.AppSettings["KeywordsFilePath"];

        public static readonly string ApkFiles = ConfigurationManager.AppSettings["ApkFiles"];

        /// <summary>
        /// 根据要保存的文件类型，返回对应的文件保存路径配置信息
        /// </summary>
        /// <param name="fileType">文件类型</param>
        /// <returns></returns>
        public static string GetFileSavePath(int fileType)
        {
            switch (fileType)
            {
                case 1:
                    return StationFilesPath;
                case 2:
                    return PersonPhotos;
                case 3:
                    return DriveFiles;
                case 4:
                    return ExamFiles;
                case 5:
                    return AnnounceFiles;
                case 6:
                    return ApkFiles;
                default:
                    return string.Empty;
            }
        }

        public static List<string> GetFileExtensions()
        {
            var config = ConfigurationManager.AppSettings["FileExtensions"];
            if (config.IsNullOrEmpty())
            {
                return new List<string>();
            }
            else
            {
                var arr = config.Split('|');
                return new List<string>(arr);
            }
        }

        public static bool AddFileExtension(string ext)
        {
            var exts = GetFileExtensions();
            if (exts.Contains(ext))
            {
                return false;
            }
            else
            {
                exts.Add(ext);
                ConfigHelper.ChangeAppsettings("FileExtensions", string.Join("|", exts));
                return true;
            }
        }

        public static void RemoveFileExtension(string ext)
        {
            var exts = GetFileExtensions();
            if (exts.Contains(ext))
            {
                exts.Remove(ext);
                ConfigHelper.ChangeAppsettings("FileExtensions", string.Join("|", exts));
            }
        }
    }
}
