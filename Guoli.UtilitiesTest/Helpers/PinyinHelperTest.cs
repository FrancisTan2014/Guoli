using System;
using FluentAssertions;
using Guoli.Utilities.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.UtilitiesTest.Helpers
{
    [TestClass]
    public class PinyinHelperTest
    {
        [TestMethod]
        public void TestGetInitials()
        {
            var s = "谭光洪";
            var r = "TGH";
            var t = PinyinHelper.GetInitials(s).ToUpper();
            t.Should().Be(r);
        }
    }
}
