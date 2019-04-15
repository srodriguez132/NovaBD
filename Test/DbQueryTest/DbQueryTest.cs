using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace DbQueryTest
{
    [TestClass]
    public class DbQueryTest
    {
        [TestMethod]
        public void SelectTest()
        {
            string q1 = "SELECT * FROM MyTable;";
            string q2 = "SELECT column FROM MyTable;";
            string q3 = "SELECT column1, column2 FROM MyTable;";
            string q4 = "SELECT column FROM MyTable WHERE column=value;";

            //First sentence
            Match match1 = Regex.Match(q1, RegularExpressions.Select);
            string columnq1 = match1.Groups[1].Value;
            string tableq1 = match1.Groups[2].Value;

            Assert.AreEqual(columnq1, "*");
            Assert.AreEqual(tableq1, "MyTable");

            //Second sentence
            Match match2 = Regex.Match(q2, RegularExpressions.Select);
            string columnq2 = match2.Groups[1].Value;
            string tableq2 = match2.Groups[2].Value;

            Assert.AreEqual(columnq2, "column");
            Assert.AreEqual(tableq2, "MyTable");

            //Third sentence
            Match match3 = Regex.Match(q3, RegularExpressions.Select);
            string columnq3 = match3.Groups[1].Value;
            string tableq3 = match3.Groups[2].Value;

            Assert.AreEqual(columnq3, "column1, column2");
            Assert.AreEqual(tableq3, "MyTable");

            //Fourth sentence
            Match match4 = Regex.Match(q4, RegularExpressions.Select);
            string columnq4 = match4.Groups[1].Value;
            string tableq4 = match4.Groups[2].Value;
            string whereq4 = match4.Groups[3].Value;

            Assert.AreEqual(columnq4, "column");
            Assert.AreEqual(tableq4, "MyTable");
            Assert.AreEqual(whereq4, "column=value");


            
        }
        [TestMethod]
        public void DeleteTest()
        {
            string d1 = "DELETE FROM MyTable WHERE column=value;";

            Match match = Regex.Match(d1, RegularExpressions.Delete);
            string table = match.Groups[1].Value;
            string where = match.Groups[2].Value;



            Assert.AreEqual(table, "MyTable");
            Assert.AreEqual(where, "column=value");
        }

        [TestMethod]
        public void CreateDatabaseTest()
        {
            string c = "CREATE DATABASE dbname;";

            Match match = Regex.Match(c, RegularExpressions.CreateDataBase);
            string dbname = match.Groups[1].Value;

            Assert.AreEqual(dbname, "dbname");
        }
        [TestMethod]
        public void InsertTest()
        {
            string i = "INSERT INTO Mytable (column1,column2) VALUES (value1,value2);";

            Match match = Regex.Match(i, RegularExpressions.Insert);
            string table = match.Groups[1].Value;
            string column = match.Groups[2].Value;
            string value = match.Groups[3].Value;

            Assert.AreEqual(table, "Mytable");
            Assert.AreEqual(column, "column1,column2");
            Assert.AreEqual(value, "value1,value2");

        }
        [TestMethod]
        public void UpdateTest()
        {
            string u = "UPDATE Mytable SET column1=value2 WHERE column1=value1;";

            Match match = Regex.Match(u, RegularExpressions.Update);
            string table = match.Groups[1].Value;
            string set = match.Groups[2].Value;
            string where = match.Groups[3].Value;

            Assert.AreEqual(table, "Mytable");
            Assert.AreEqual(set, "column1=value2");
            Assert.AreEqual(where, "column1=value1");

        }


    }
}
