using System;
using System.Configuration;
using FluentAssertions;
using Guoli.Utilities.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.Import.Test
{
    [TestClass]
    public class FrmInitTest
    {
        [TestMethod]
        public void TestChangeConfig()
        {
            var frm = new FrmInit();
            ReflectorHelper.InvokeMethod(frm, "ChangeConfig", "test1");

            ConfigurationManager.ConnectionStrings["MainDb"].ConnectionString.Should().Be("test1");
        }
    }
}
