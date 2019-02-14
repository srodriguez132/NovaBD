using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
using System.Text.RegularExpressions;

namespace CreateTableTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateTableTest()
        {
            Match result;
            CreateTable creTab = new CreateTable();
            result = creTab.createTable("CREATE TABLE table1 (name string, age int);");
            Assert.AreEqual("table1", result.Groups[1].Value);
            Assert.AreEqual("name string, age int", result.Groups[2].Value);
        }
    }
}
