using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace select
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelectTest()
        {
            Match result;
            Select s = new Select();
            result = s.select("SELECT column, column1 FROM table WHERE id = id1;");
            Assert.AreEqual("column", result.Groups[1].Value);
            Assert.AreEqual(", column1 ", result.Groups[2].Value);
            Assert.AreEqual("column1", result.Groups[3].Value);
            Assert.AreEqual("table", result.Groups[4].Value);
            Assert.AreEqual(" WHERE id = id1;", result.Groups[5].Value);
            Assert.AreEqual("id", result.Groups[6].Value);
            Assert.AreEqual("id1", result.Groups[7].Value);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Match result;
            Select d = new Select();
            result = d.delete("DELETE FROM table WHERE id=id1;");
            Assert.AreEqual("table", result.Groups[1].Value);
            Assert.AreEqual("id", result.Groups[2].Value);
            Assert.AreEqual("id1", result.Groups[3].Value);



        }
    }
}
