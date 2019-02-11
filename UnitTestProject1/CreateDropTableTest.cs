using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace UnitTestProject1
{
    [TestClass]
    public class CreateDropTableTest
    {
        [TestMethod]
        public void TestCreateDatabase()
        {
            Match result;
            CreateDropTable cdt = new CreateDropTable();
            result= cdt.CreateDataBase("CREATE DATABASE database;");
            Assert.AreEqual("database", result.Groups[1].Value);
        }
        [TestMethod]
        public void TestDropDatabase()
        {
            Match result;
            CreateDropTable cdt = new CreateDropTable();
            result = cdt.DropDataBase("DROP DATABASE database;");
            Assert.AreEqual("database", result.Groups[1].Value);
        }
        [TestMethod]
        public void TestDropTable()
        {
            Match result;
            CreateDropTable cdt = new CreateDropTable();
            result = cdt.DropTable("DROP TABLE database;");
            Assert.AreEqual("database", result.Groups[1].Value);
        }
    }

}
