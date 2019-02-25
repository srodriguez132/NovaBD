﻿using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace SelectTest
{
    [TestClass]
    public class SelectTest
    {
        [TestMethod]
        public void selectTest()
        {
            Match result;
            Select s = new Select();
            result = s.select("SELECT column, column1 FROM table WHERE id = id1;");
            Assert.AreEqual("column", result.Groups[1].Value);
            Assert.AreEqual(", column1 ", result.Groups[2].Value);
            Assert.AreEqual("column1", result.Groups[3].Value);
            Assert.AreEqual("table", result.Groups[4].Value);
            Assert.AreEqual(" WHERE id = id1;", result.Groups[5].Value);
            Assert.AreEqual("id", result.Groups[6].Value);
            Assert.AreEqual("id1", result.Groups[7].Value);
        }
    }
}