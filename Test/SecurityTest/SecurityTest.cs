using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MiniSQLEngine;

namespace SecurityTest
{
    [TestClass]
    public class SecurityTest
    {
        [TestMethod]
        public void addUserTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));
            MiniSQLEngine.MiniSQL q1 = db.Parse("ADD USER (user, password, security_profile);");
            Assert.IsInstanceOfType(q1, typeof(AddUser));
        }
        [TestMethod]
        public void createSecurityTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));      
            MiniSQLEngine.MiniSQL q1 = db.Parse("CREATE SECURITY PROFILE security_profile;");
            Assert.IsInstanceOfType(q1, typeof(CreateSecurity));
        }
        [TestMethod]
        public void dropSecurityTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));
            MiniSQLEngine.MiniSQL q1 = db.Parse("DROP SECURITY PROFILE security_profile;");
            Assert.IsInstanceOfType(q1, typeof(DropSecurity));
        }
        [TestMethod]
        public void grantTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));
            MiniSQLEngine.MiniSQL q1 = db.Parse("GRANT privilege_type ON table TO security_profile;");
            Assert.IsInstanceOfType(q1, typeof(Grant));
        }
        [TestMethod]
        public void revokeTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));
            MiniSQLEngine.MiniSQL q1 = db.Parse("REVOKE privilege_type ON table TO security_profile;");
            Assert.IsInstanceOfType(q1, typeof(Revoke));
        }
        [TestMethod]
        public void deleteUserTest()
        {
            Database db = new Database("name");
            db.setCurrentUser(db.GetUser("admin"));         
            MiniSQLEngine.MiniSQL q1 = db.Parse("DELETE USER admin;");
            Assert.IsInstanceOfType(q1, typeof(DeleteUser));
        }
    }
}
