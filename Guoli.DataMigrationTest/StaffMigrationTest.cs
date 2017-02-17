using System;
using System.Linq;
using FluentAssertions;
using Guoli.Bll;
using Guoli.DataMigration;
using Guoli.Model;
using Guoli.Model.OracleModels;
using Guoli.Utilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DataMigrationTest
{
    [TestClass]
    public class StaffMigrationTest
    {
        [TestMethod]
        public void TestImportNewData()
        {
            // 导入员工之前必须先导入部门、岗位
            var departImport = new DepartmentMigration();
            departImport.ImportNewData();

            var postImport = new PostMigragion();
            postImport.ImportNewData();

            var testInstance = new StaffMigration();
            testInstance.ImportNewData();

            var totalCount = 7063;
            var allStaff = new PersonInfoBll().QueryAll().ToList();
            allStaff.Should().HaveCount(totalCount, $"because the total count of the data source is {totalCount}");

            var single = allStaff.Find(p => p.WorkNo == "2920133");
            single.Should().NotBeNull();
            single.Name.Should().Be("杨凤山");
            single.BirthDate.Should().Be(new DateTime(1960, 12, 1, 12, 0, 0));
            single.Password.Should().Be("0133".GetMd5());

            var dbLogs = new DbUpdateLogBll().QueryList($"TableName='{nameof(PersonInfo)}'");
            dbLogs.Should().HaveCount(totalCount);

            var relations = new PrimaryIdRelationBll().QueryAll();
            relations.Should().HaveCount(totalCount);

            var maxId = new OracleTableMaxIdBll().QuerySingle($"TableName='{nameof(Z_JCYY_BASEPERSONNEL)}'");
            maxId.Should().NotBeNull();
            maxId?.MaxId.Should().NotBeNullOrEmpty()
                .And.Subject.Should().Be("404990019");
        }
    }
}
