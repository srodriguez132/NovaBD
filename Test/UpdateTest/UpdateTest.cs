using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
namespace UpdateTest
{
    [TestClass]
    public class UpdateTest
    {

        [TestMethod]
        public void updateTest()
        {
            Match result;
          
            result = upd.update("UPDATE table SET column=value WHERE condition;");

            Assert.AreEqual("table", result.Groups[1].Value);
            Assert.AreEqual("column=value", result.Groups[2].Value);
            Assert.AreEqual("condition", result.Groups[3].Value);

        }
    }
}
