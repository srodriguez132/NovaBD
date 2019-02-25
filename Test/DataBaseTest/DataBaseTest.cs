using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
namespace DataBaseTest
{
    [TestClass]
    public class DataBaseTest
    {
        [TestMethod]
        public void parseTest()
        {
            Database db = new Database("name");
            MiniSQLEngine.MiniSQL q1 = db.Parse("DELETE FROM table WHERE id = id1;");
            Assert.IsInstanceOfType(q1, typeof(Delete));
           
        }
    }
}
