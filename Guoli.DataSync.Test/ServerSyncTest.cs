using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.DataSync.Test
{
    [TestClass]
    public class ServerSyncTest
    {
        [TestMethod]
        public void TestGetLastPosition()
        {
            var sync = new ServerSync();
            var testId = "not exists";
            var p = sync.GetLastPosition(testId);
            p.Should().Be(0);
        }

        [TestMethod]
        public void TestGetDbLog()
        {
            var sync = new ServerSync();
            var log = sync.GetDbLog(617440);
            log.Should().NotBeNull();
            log.Count.Should().Be(5);
            log[4].TargetId.Should().Be(432770);
        }

        [TestMethod]
        public void TestDataSync()
        {
            //var sync = new ServerSync();
            //var data = sync.GetNewData("test");
            //var path = @"E:\test-sync";
            //sync.CopyNewFiles(data.PathList, "", path);
        }
    }
}
