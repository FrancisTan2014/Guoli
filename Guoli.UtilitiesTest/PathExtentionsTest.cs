using System;
using FluentAssertions;
using Guoli.Utilities.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Guoli.UtilitiesTest
{
    [TestClass]
    public class PathExtentionsTest
    {
        [TestMethod]
        public void TestMapPath1()
        {
            var path = PathExtension.MapPath("/test.txt");
            path.Should().Be(@"E:\工作\国力时代\SourceCode\GuoLi\Guoli.UtilitiesTest\bin\Debug/test.txt");
        }

        [TestMethod]
        public void TestMapPath2()
        {
            var path = PathExtension.MapPath("test/dir");
            path.Should().Be(@"E:\工作\国力时代\SourceCode\GuoLi\Guoli.UtilitiesTest\bin\Debug\test/dir");
        }
    }
}
