using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace select
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SelectTest()
        {
            Match result;
            Select s = new Select();
            result = s.select("SELECT * FROM table ;");
            Assert.AreEqual("*", result.Groups[1].Value);
            
        }

        public void DeleteTest()
        {
            Match result;

        }
    }
}
