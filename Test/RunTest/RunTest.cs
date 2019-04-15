using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace RunTest
{
    [TestClass]
    public class RunTest
    {
        [TestMethod]
        public void ExecuteTest()
        {
            string name = "db";
            string user = "admin";
            string password = "admin";
            

            Database db = new Database(name, user, password);
            db.Query("CREATE TABLE Mytable (Name TEXT, Age INT);");
            db.Query("INSERT INTO Mytable VALUES ('Eva', 18);");
            db.Query("SELECT * WHERE Name='Eva';");
            
        }
    }
}
