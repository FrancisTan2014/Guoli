using Guoli.Bll;
using Guoli.Model;
using Guoli.Utilities.Extensions;
using Guoli.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Guoli.Admin.Utilities
{
    /// <summary>
    /// 提供对上传文件进行处理的方法
    /// </summary>
    public static class FileProcesser
    {
        /// <summary>
        /// 将上传的文件进行格式转换处理，若文件格式符合处理条件，则在文件处理完成之后会将处理后得到的新文件地址赋值给 fileModel 的 FilePath 字段并返回
        /// </summary>
        /// <param name="fileModel"><see cref="TraficFiles"/>类的实体对象</param>
        public static TraficFiles Format(TraficFiles fileModel)
        {
            try
            {
                var fileName = PathExtension.MapPath(fileModel.FilePath);
                var path = Path.GetDirectoryName(fileName);
                var htmlFilesPath = Path.Combine(path, Guid.NewGuid().ToString());

                var ext = Path.GetExtension(fileName).ToLower();
                switch (ext)
                {
                    case ".doc":
                    case ".docx":
                        FileHelper.Word2Html(fileName, htmlFilesPath);
                        break;

                    //case ".pdf":
                    //    FileHelper.Pdf2Html(fileName, htmlFilesPath);
                    //    break;

                    default:
                        throw new NotImplementedException();
                }

                // 将 __html 中的文件打包压缩成 zip 格式的文件
                var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileName);
                var zipFileName = Path.Combine(path, fileNameWithoutExtension + ".zip");
                FileHelper.Zip(zipFileName, htmlFilesPath);

                // 删除 __html 目录
                Directory.Delete(htmlFilesPath, true);

                // 将 zip 文件路径处理成相对路径
                fileName = fileName.Replace("\\", "/");
                var webDir = fileName.Replace(fileModel.FilePath, "");
                fileModel.FilePath = zipFileName.Replace("\\", "/").Replace(webDir, "");
                fileModel.FilePath = fileModel.FilePath.StartsWith("/") ? fileModel.FilePath : $"/{fileModel.FilePath}";

                var n = fileModel.FileName;
                fileModel.FileExtension = ".zip";
                fileModel.FileName = Path.GetFileNameWithoutExtension(n) + fileModel.FileExtension;
                return fileModel;
            }
            catch (Exception ex)
            {
                ExceptionLogBll.ExceptionPersistence(nameof(FileProcesser), nameof(FileProcesser), ex);
                return fileModel;
            }
        }
    }
}