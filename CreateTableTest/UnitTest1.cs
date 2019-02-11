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
            result = creTab.createTable("CREATE TABLE tabla (name string, edad int);");
            Assert.AreEqual("tabla", result.Groups[1].Value);
            Assert.AreEqual("name string, edad int", result.Groups[2].Value);
        }
    }
}
