using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Guoli.Bll;

namespace Guoli.Import
{
    public static class ImportHelper
    {
        /// <summary>
        /// 清空基础数据，将对如下表格执行 TUNCATE 操作：
        ///     TrainMoment, TrainNoLine, LineStations, BaseStation, BaseLine, TrainNo
        /// 并将删除 DbUpdateLog 表中与以上表格相关的数据
        /// </summary>
        public static void ClearBaseData()
        {
            var tables = new List<string> { "TrainMoment", "TrainNoLine", "LineStations", "BaseStation", "BaseLine", "TrainNo" };
            var truncate = $"TRUNCATE TABLE {string.Join("; TRUNCATE TABLE ", tables)};";
            var delete = $"DELETE FROM DbUpdateLog WHERE TableName IN( {string.Join(", ", tables.Select(s => $"'{s}'"))} );";
            var bll = new TrainNoBll();
            bll.ExecuteSql(truncate + delete);
        }
    }
}
