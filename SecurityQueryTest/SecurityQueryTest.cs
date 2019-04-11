using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;


namespace SecurityQueryTest
{
    [TestClass]
    public class SecurityQueryTest
    {
        [TestMethod]
        public void AddUserQueryTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));
            
            string q1 = "ADD USER (user, password, security_profile);";

            Match match = Regex.Match(q1, RegularExpressions.AddUser);
            string u = match.Groups[1].Value;
            string pass = match.Groups[2].Value;
            string security_profile = match.Groups[3].Value;

            Assert.AreEqual(u, "user");
            Assert.AreEqual(pass, "password");
            Assert.AreEqual(security_profile, "security_profile");
        }
        [TestMethod]
        public void CreateSecurityQueryTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));

            string q1 = "CREATE SECURITY PROFILE security_profile;";

            Match match = Regex.Match(q1, RegularExpressions.CreateSecurity);
            string profile = match.Groups[1].Value;

            Assert.AreEqual(profile, "security_profile");
        }
        [TestMethod]
        public void DeleteUserQueryTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));

            string q1 = "DELETE USER admin;";

            Match match = Regex.Match(q1, RegularExpressions.DeleteUser);
            string name = match.Groups[1].Value;

            Assert.AreEqual(name, "admin");
        }
        [TestMethod]
        public void DropSecurityQueryTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));

            string q1 = "DROP SECURITY PROFILE security_profile;";

            Match match = Regex.Match(q1, RegularExpressions.DropSecurity);
            string profile = match.Groups[1].Value;

            Assert.AreEqual(profile, "security_profile");
        }
        [TestMethod]
        public void GrantQueryTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));

            string q1 = "GRANT privilege_type ON table TO security_profile;";

            Match match = Regex.Match(q1, RegularExpressions.Grant);
            string type = match.Groups[1].Value;
            string table = match.Groups[2].Value;
            string security_profile = match.Groups[3].Value;

            Assert.AreEqual(type, "privilege_type");
            Assert.AreEqual(table, "table");
            Assert.AreEqual(security_profile, "security_profile");
        }
        [TestMethod]
        public void RevokeQueryTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));

            string q1 = "REVOKE privilege_type ON table TO security_profile;";

            Match match = Regex.Match(q1, RegularExpressions.Revoke);
            string type = match.Groups[1].Value;
            string table = match.Groups[2].Value;
            string security_profile = match.Groups[3].Value;

            Assert.AreEqual(type, "privilege_type");
            Assert.AreEqual(table, "table");
            Assert.AreEqual(security_profile, "security_profile");
        }

    }

}
