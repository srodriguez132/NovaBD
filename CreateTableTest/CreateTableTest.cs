using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
using System.Text.RegularExpressions;

namespace CreateTableTest
{
    [TestClass]
    public class CreateTableTest
    {
        [TestMethod]
        public void createTableTest()
        {
            Match result;
            CreateTable creTab = new CreateTable();
            result = creTab.createTable("CREATE TABLE table1 (name string, age int);");
            Assert.AreEqual("table1", result.Groups[1].Value);
            Assert.AreEqual("name string, age int", result.Groups[2].Value);
        }
    }
}
