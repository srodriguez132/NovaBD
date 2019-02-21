using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace InsertIntoUpdateTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            Match result;
            Insert insert = new Insert();
            result = insert.InsertInto("INSERT INTO table (column) VALUES (value);");

            Assert.AreEqual("table", result.Groups[1].Value);
            Assert.AreEqual("column", result.Groups[2].Value);
            Assert.AreEqual("value", result.Groups[3].Value);

        }

        [TestMethod]
        public void TestMethod2()
        {
            Match result;
            Insert upd = new Insert();
            result = upd.Update("UPDATE table SET column=value WHERE condition;");

            Assert.AreEqual("table", result.Groups[1].Value);
            Assert.AreEqual("column=value", result.Groups[2].Value);
            Assert.AreEqual("condition", result.Groups[3].Value);

        }
    }
}
