﻿using System;
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
            MiniSQLEngine.MiniSQL q1 = db.Parse("CREATE DATABASE database;");
            Assert.IsInstanceOfType(q1, typeof(CreateDataBase));
        }
        [TestMethod]
        public void parseCreateTableTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("CREATE TABLE table (column_def_1);");
            Assert.IsInstanceOfType(q1, typeof(CreateTable));
        }
        [TestMethod]
        public void parseDropTableTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("DROP TABLE table;");
            Assert.IsInstanceOfType(q1, typeof(DropTable));
        }
        [TestMethod]
        public void parseInsertTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("INSERT INTO table (column) VALUES (column1);");
            Assert.IsInstanceOfType(q1, typeof(Insert));
        }
        [TestMethod]
        public void parseUpdateTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("UPDATE table SET id=id1 WHERE id=id1;");
            Assert.IsInstanceOfType(q1, typeof(Update));
        }
        [TestMethod]
        public void parseBackUpTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("BACKUP DATABASE database TO DISK = 'disk';");
            Assert.IsInstanceOfType(q1, typeof(BackupDatabase));
        }
        [TestMethod]
        public void parseDropDataBaseTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("DROP DATABASE database;");
            Assert.IsInstanceOfType(q1, typeof(DropDataBase));
        }
    }
}
