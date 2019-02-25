using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace CreateDataBaseTest
{
    [TestClass]
    public class CreateDataBaseTest
    {
        [TestMethod]
        public void CreateDatabaseTest()
        {
            Match result;
            CreateDataBase cdb = new CreateDataBase();


            result = cdb.CreateDatabase("CREATE DATABASE database;");

            Assert.AreEqual("database", result.Groups[1].Value);
        }
    }
}
