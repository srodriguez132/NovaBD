using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void MiniSQLParse1()
        {
            string result;
            Engine engine = new Engine();
            engine.query("Select * from Table1", out result);
            Assert.AreEqual(Constants.NotImplementedError, result);
        }
    }
}
