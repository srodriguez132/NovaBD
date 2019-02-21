using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace InsertTest
{
    [TestClass]
    public class InsertTest
    {

        [TestMethod]
        public void insertTest()
        {
            Match result;
            Insert insert = new Insert();
            result = insert.InsertInto("INSERT INTO table (column) VALUES (value);");

            Assert.AreEqual("table", result.Groups[1].Value);
            Assert.AreEqual("column", result.Groups[2].Value);
            Assert.AreEqual("value", result.Groups[3].Value);

        }
    }
}
