using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;
namespace BackupDatabaseTest
{
    [TestClass]
    public class BackpDatabaseTest
    {
        [TestMethod]
        public void TestBackupDatabase()
        {
            Match result;
            BackupDatabase bckd = new BackupDatabase();

            result = bckd.BackupDtb("BACKUP DATABASE prueba TO DISK = 'filepath';");

            Assert.AreEqual("prueba", result.Groups[1].Value);
            Assert.AreEqual("'filepath'", result.Groups[2].Value);


        }
    }
}