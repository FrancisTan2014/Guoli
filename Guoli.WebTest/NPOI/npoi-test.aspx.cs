using Guoli.Utilities.Extensions;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Guoli.WebTest.NPOI
{
    public partial class npoi_test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var sheetIndex = Request["index"].ToInt32();
            var absolutePath = @"E:\工作\国力时代\Documents\201402廉政准则廉洁从业党纪条例题库.xls";
            using (var fileStream = new FileStream(absolutePath, FileMode.Open, FileAccess.Read))
            {
                var workBook = new HSSFWorkbook(fileStream);
                var sheet = workBook.GetSheetAt(sheetIndex);
                var rows = sheet.GetRowEnumerator();

                var counter = 0;
                while (rows.MoveNext())
                {
                    counter++;
                    var row = (HSSFRow)rows.Current;
                    Response.Write(string.Format("第{0}行：", counter));
                    Response.Write(string.Format("此行共有{0}个单元格，其中第一个单元格的值为{1} <br/>", row.Cells.Count, row.Cells[0]));
                }

                var i = 0;
            }
        }
    }
}