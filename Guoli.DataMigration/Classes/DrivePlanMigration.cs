using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Guoli.Model;
using Guoli.Model.OracleModels;
using Guoli.Utilities.Extensions;

namespace Guoli.DataMigration
{
    public class DrivePlanMigration: OracleMigration<VHISPLANINFO, DrivePlan>
    {
        protected override string OracleTableName => nameof(VHISPLANINFO);
        protected override string OracleTablePrimaryKeyName => nameof(VHISPLANINFO.ID);
        protected override string SqlserverTableName => nameof(DrivePlan);
        protected override string SqlserverTablePrimaryKeyName => nameof(DrivePlan.Id);

        protected override bool NeedToUpdateAll => false;

        protected override bool NeedToCachePrimaryRelation => false;

        protected override bool HasEdited(VHISPLANINFO oracleModel, DrivePlan sqlserverModel) => true;

        protected override void UpdateSqlserverModel(VHISPLANINFO oracleEntity, DrivePlan sqlserverEntity)
        {
            
        }

        protected override dynamic MapEntity(VHISPLANINFO oracleEntity)
        {
            return new DrivePlan
            {
                AttendTime = oracleEntity.PLANONDUTYTIME ?? DateTimeExtension.UnknownDateTime,
                StartTime = oracleEntity.PLANCALLDUTYTIME ?? DateTimeExtension.UnknownDateTime,
                DriverName = oracleEntity.HNAMES ?? string.Empty,
                DriverNo = oracleEntity.WORKNO ?? string.Empty,
                ViceDriverName = oracleEntity.HNAMES2 ?? string.Empty,
                ViceDriverNo = oracleEntity.WORKNO2 ?? string.Empty,
                StudentName = oracleEntity.HNAMES3 ?? string.Empty,
                StudentNo = oracleEntity.WORKNO3 ?? string.Empty,
                OtherName1 = oracleEntity.HNAMES4 ?? string.Empty,
                OtherNo1 = oracleEntity.WORKNO4 ?? string.Empty,
                LineName = oracleEntity.LINENAME ?? string.Empty,
                TrainCode = oracleEntity.TRAINCODE ?? string.Empty,
                LocoType = oracleEntity.LOCOMOTIVE ?? string.Empty
            };
        }

        protected override object GetMaxId(IEnumerable<VHISPLANINFO> source)
        {
            return source.Select(item => item.MOBILENUMBER4.ToInt32()).Max();
        }

        protected override IEnumerable<VHISPLANINFO> GetDataFromSourdeDb(OracleTableMaxId maxId)
        {
            var type = typeof (VHISPLANINFO);
            var specialColumn = "MOBILENUMBER4";
            var selectColumns = string.Join(",", type.GetProperties().Select(p => p.Name))
                .Replace(specialColumn, $"ROWNUM AS {specialColumn}");
            var condition = maxId == null ? string.Empty : $"WHERE {specialColumn}>{maxId.MaxId}";
            var sql = $"SELECT * FROM (SELECT {selectColumns} FROM {nameof(VHISPLANINFO)}) {condition}";

            return OracleBaseBll.QueryBySql(sql);
        }
    }
}
