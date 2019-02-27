using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
namespace DataBaseTest
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void parseDeleteTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("DELETE FROM table WHERE id = id1;");
            Assert.IsInstanceOfType(q1, typeof(Delete));          
        }
        [TestMethod]
        public void parseCreateDatabaseTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("CREATE DATABASE database");
            Assert.IsInstanceOfType(q1, typeof(CreateDataBase));
        }
        [TestMethod]
        public void parseCreateTableTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("CREATE TABLE table");
            Assert.IsInstanceOfType(q1, typeof(CreateTable));
        }
        [TestMethod]
        public void parseDropTableTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("DROP TABLE table");
            Assert.IsInstanceOfType(q1, typeof(DropTable));
        }
        [TestMethod]
        public void parseInsertTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("INSERT INTO table VALUES ()");
            Assert.IsInstanceOfType(q1, typeof(Insert));
        }
    }
}
