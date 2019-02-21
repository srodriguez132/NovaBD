using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace DeleteTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Match result;
            Delete d = new Delete();
            result = d.delete("DELETE FROM table WHERE id=id1;");
            Assert.AreEqual("table", result.Groups[1].Value);
            Assert.AreEqual("id", result.Groups[2].Value);
            Assert.AreEqual("id1", result.Groups[3].Value);
        }
    }
}
