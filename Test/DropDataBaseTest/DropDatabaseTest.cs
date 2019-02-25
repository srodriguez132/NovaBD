using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
namespace DropDataBaseTest
{
    [TestClass]
    public class DropDataBaseTest
    {
        [TestMethod]
        public void DropDatabaseTest()
        {
            Match result;
            DropDataBase ddb = new DropDataBase();
            result = ddb.DropDatabase("DROP DATABASE database;");
            Assert.AreEqual("database", result.Groups[1].Value);
        }
    }
}
