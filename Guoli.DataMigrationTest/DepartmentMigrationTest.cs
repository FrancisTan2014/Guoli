using System;
using System.Linq;
using FluentAssertions;
using Guoli.Bll;
using Guoli.DataMigration;
using Guoli.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DataMigrationTest
{
    [TestClass]
    public class DepartmentMigrationTest
    {
        [TestMethod]
        public void TestImportNewData()
        {
            TestSuite.CleanTestDb();

            var importInstance = new DepartmentMigration();
            importInstance.ImportNewData();

            var departBll = new DepartInfoBll();
            var departs = departBll.QueryAll().ToList();
            departs.Should().HaveCount(37, "because the table 'Y_JCYY_BASEDEPARTMENT' in oracle has 37 rows.");
            //departs.Should().Contain(depart => depart.DepartmentName == "集宁机务段");

            var jnDepot = departs.Find(d => d.DepartmentName == "集宁机务段");
            jnDepot.Should().NotBeNull();
            jnDepot?.DepartmentName.Should().NotBeNullOrEmpty().And.Be("集宁机务段");
            jnDepot?.ParentId.Should().Be(0);

            var jnyyc = departs.Find(d => d.DepartmentName == "集宁运用车间");
            jnyyc.Should().NotBeNull();
            jnyyc?.ParentId.Should().Be(jnDepot?.Id);

            var dbupdateLogBll = new DbUpdateLogBll();
            var dbupdateLogs = dbupdateLogBll.QueryList($"TableName='{nameof(DepartInfo)}'").ToList();
            dbupdateLogs.Should().HaveCount(37);

            var relationBll = new PrimaryIdRelationBll();
            var relations = relationBll.QueryAll().ToList();
            relations.Should().HaveCount(37);

            var maxBll = new OracleTableMaxIdBll();
            var maxIdModel = maxBll.QuerySingle($"TableName='Y_JCYY_BASEDEPARTMENT'");
            maxIdModel.Should().NotBeNull();
            maxIdModel.MaxId.Should().Be("404100000");
        }

        [TestMethod]
        public void TestUpdateEditedData()
        {
            var updateInstance = new DepartmentMigration();
            updateInstance.UpdateEditedData();

            var departs = new DepartInfoBll().QueryAll().ToList();
            var editedDepart = departs.Find(d => d.DepartmentName == "呼南运用车间");
            editedDepart.Should().NotBeNull();

            var dbUpdateLog = new DbUpdateLogBll().QueryList("TableName='DepartInfo' AND UpdateType=2");
            dbUpdateLog.Should().HaveCount(2);
        }
    }
}
