using System;
using FluentAssertions;
using Guoli.Bll;
using Guoli.DataMigration;
using Guoli.Model;
using Guoli.Model.OracleModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DataMigrationTest
{
    [TestClass]
    public class PostMigragionTest
    {
        [TestMethod]
        public void TestImportNewData()
        {
            var importInstance = new PostMigragion();
            importInstance.ImportNewData();

            var posts = new PostsBll().QueryAll();
            posts.Should()
                .HaveCount(192, "because there are only 192 rows data in the table j_jcyy_basepost of data source");

            var dbUpdateLogs = new DbUpdateLogBll().QueryAll();
            dbUpdateLogs.Should().HaveCount(192, "because I just insert 192 rows data to the table Posts");

            var relations = new PrimaryIdRelationBll().QueryAll();
            relations.Should()
                .HaveCount(192, "becaust there are only 192 rows data in the table j_jcyy_basepost of data source");

            var maxId = new OracleTableMaxIdBll().QuerySingle($"TableName='{nameof(J_JCYY_BASEPOST)}'");
            maxId.Should().NotBeNull();
            maxId?.MaxId.Should().Be("226");
        }

        [TestMethod]
        public void TestUpdateEditedData()
        {
            var updateInstance = new PostMigragion();
            updateInstance.UpdateEditedData();

            var editedModel = new PostsBll().QuerySingle("PostName='测试修改安全监控员'");
            editedModel.Should().NotBeNull();

            var dbUpdateLog = new DbUpdateLogBll().QuerySingle($"TableName='{nameof(Posts)}' AND UpdateType=2");
            dbUpdateLog.Should().NotBeNull();
        }
    }
}
