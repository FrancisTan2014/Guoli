using System.Collections.Generic;
using System.Linq;
using Guoli.Model;
using Guoli.Model.OracleModels;
using Guoli.Utilities.Extensions;

namespace Guoli.DataMigration
{
    public class DepartmentMigration : OracleMigration<Y_JCYY_BASEDEPARTMENT, DepartInfo>
    {
        protected override string OracleTableName => nameof(Y_JCYY_BASEDEPARTMENT);
        protected override string OracleTablePrimaryKeyName => nameof(Y_JCYY_BASEDEPARTMENT.DEPTID);
        protected override string SqlserverTableName => nameof(DepartInfo);
        protected override string SqlserverTablePrimaryKeyName => nameof(DepartInfo.Id);

        public DepartmentMigration()
        {
            DataProcessEvent += DepartmentMigration_DataProcessEvent;
        }

        private IList<Y_JCYY_BASEDEPARTMENT> DepartmentMigration_DataProcessEvent(
            IEnumerable<Y_JCYY_BASEDEPARTMENT> data)
        {
            var result = new List<Y_JCYY_BASEDEPARTMENT>();

            for (int i = 0; i < 3; i++)
            {
                result.AddRange(data.Where(item => item.STRUCTURELEVEL == i));
            }

            return result;
        }

        protected override bool HasEdited(Y_JCYY_BASEDEPARTMENT oracleModel, DepartInfo sqlserverModel)
        {
            var parentId = SearchId(oracleModel.UPPERDEPTID).ToInt32();
            return oracleModel.DEPTNAME != sqlserverModel.DepartmentName || parentId != sqlserverModel.ParentId;
        }

        protected override void UpdateSqlserverModel(Y_JCYY_BASEDEPARTMENT oracleEntity, DepartInfo sqlserverEntity)
        {
            var parentId = SearchId(oracleEntity.UPPERDEPTID).ToInt32();
            if (sqlserverEntity.ParentId != parentId)
            {
                sqlserverEntity.ParentId = parentId;
            }

            if (sqlserverEntity.DepartmentName != oracleEntity.DEPTNAME)
            {
                sqlserverEntity.DepartmentName = oracleEntity.DEPTNAME;
            }
        }

        protected override dynamic MapEntity(Y_JCYY_BASEDEPARTMENT oracleEntity)
        {
            var depart = new DepartInfo {DepartmentName = oracleEntity.DEPTNAME};
            if (oracleEntity.STRUCTURELEVEL > 0)
            {
                var parentId = SearchId(oracleEntity.UPPERDEPTID);
                depart.ParentId = parentId.ToInt32();
            }

            return depart;
        }

        protected override object GetMaxId(IEnumerable<Y_JCYY_BASEDEPARTMENT> source)
        {
            return source.Select(d => d.DEPTID.ToInt32()).Max();
        }

    } // end class

}

