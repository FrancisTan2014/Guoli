using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using Guoli.Utilities.Extensions;

namespace Guoli.Utilities.Helpers
{
    /// <summary>
    /// 文件操作帮助类
    /// </summary>
    /// <since>2016-09-18</since>
    public static class FileHelper
    {
        /// <summary>
        /// 对写文件的简单封装
        /// </summary>
        /// <param name="path">要写入的文件绝对路径（不存在会自动创建）</param>
        /// <param name="txt">待写入的文本</param>
        public static void Write(string path, string txt)
        {
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (var writer = new StreamWriter(fs))
                {
                    writer.Write(txt);
                }
            }
        }

        /// <summary>
        /// 将指定目录压缩为zip包
        /// </summary>
        /// <param name="zipFilePath">zip文件绝对路径</param>
        /// <param name="targetDir">待压缩的目录</param>
        public static void Zip(string zipFilePath, string targetDir)
        {
            if (!Directory.Exists(targetDir))
            {
                throw new DirectoryNotFoundException();
            }

            var zip = new FastZip();
            zip.CreateZip(zipFilePath, targetDir, true, string.Empty);
        }

        /// <summary>
        /// 将指定zip压缩包解压到指定目录下
        /// </summary>
        /// <param name="zipFilePath">压缩包文件绝对路径</param>
        /// <param name="extractPath">解压路径</param>
        public static void ExtractZip(string zipFilePath, string extractPath)
        {
            var zip = new FastZip();
            zip.ExtractZip(zipFilePath, extractPath, string.Empty);
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// </summary>
        /// <param name="stream">The text file stream to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(FileStream stream)
        {
            // Read the BOM
            var bom = new byte[4];
            stream.Read(bom, 0, 4);
            stream.Seek(0, SeekOrigin.Begin);

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return Encoding.UTF32;
            return Encoding.Default;
        }

        /// <summary>
        /// 将给定的 word 文档（.doc|.docx）转换为 html 
        /// </summary>
        /// <param name="docFileName">word 文档绝对路径</param>
        /// <param name="targetPath">转换后的 html 文件存储路径，若此参数为 null，则 html 文件存储路径将与 word 文档一致</param>
        /// <exception cref="FileNotFoundException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="Exception"></exception>
        public static void Word2Html(string docFileName, string targetPath = null)
        {
            if (!File.Exists(docFileName))
            {
                throw new FileNotFoundException();
            }

            var ext = Path.GetExtension(docFileName).ToLower();
            if (ext != ".doc" && ext != ".docx")
            {
                throw new InvalidOperationException("此函数仅支持转换“.doc|.docx”格式的文件");
            }

            if (!targetPath.IsNullOrEmpty())
            {
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
            }
            else
            {
                targetPath = Path.GetDirectoryName(docFileName);
            }

            var htmlFilename = Path.Combine(targetPath, Path.GetFileNameWithoutExtension(docFileName) + ".html");

            #region Microsoft.Office.Interop.Word
            //var word = new ApplicationClass();
            //Document doc = null;

            //try
            //{
            //    doc = word.Documents.Open(docFileName);

            //    doc.SaveAs2(htmlFilename, WdSaveFormat.wdFormatHTML);
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
            //finally
            //{
            //    doc?.Close();
            //    word.Quit();
            //}
            #endregion

            // Aspose.Words
            var doc = new Aspose.Words.Document(docFileName);
            doc.Save(htmlFilename, new Aspose.Words.Saving.HtmlSaveOptions { SaveFormat = Aspose.Words.SaveFormat.Html, Encoding = Encoding.GetEncoding("GB2312") });
        }

        /// <summary>
        /// 判断给定文件是否为 Microsoft Office Word 文档（后缀名是否为 .doc 或者 .docx）
        /// </summary>
        /// <param name="fileName">待判断的文件名称</param>
        /// <returns></returns>
        public static bool IsOfficeWordDocument(string fileName)
        {
            if (fileName.IsNullOrEmpty())
            {
                return false;
            }

            var ext = Path.GetExtension(fileName).ToLower();
            return ext == ".doc" || ext == ".docx";
        }

        public static void Pdf2Html(string filename, string targetPath = null)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            
            if (!IsPdfDocument(filename))
            {
                throw new InvalidOperationException("此函数仅支持转换“.pdf”格式的文件");
            }

            if (!targetPath.IsNullOrEmpty())
            {
                if (!Directory.Exists(targetPath))
                {
                    Directory.CreateDirectory(targetPath);
                }
            }
            else
            {
                targetPath = Path.GetDirectoryName(filename);
            }

            var htmlFilename = Path.Combine(targetPath, Path.GetFileNameWithoutExtension(filename) + ".html");
            var doc = new Aspose.Pdf.Document(filename);
            //doc.Save(htmlFilename, Aspose.Pdf.SaveFormat.Html);
            doc.Save(htmlFilename, new Aspose.Pdf.HtmlSaveOptions { DocumentType = Aspose.Pdf.HtmlDocumentType.Html5 });
        }

        public static bool IsPdfDocument(string filename)
        {
            if (filename.IsNullOrEmpty())
            {
                return false;
            }

            var ext = Path.GetExtension(filename).ToLower();
            return ext == ".pdf";
        }
    }
}
