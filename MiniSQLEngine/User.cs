using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
  public class User

    {
        private string name;
        private string password;
        private Security_profile secprof;

        public User (string pName, string pPassword, Security_profile pSecprof)
        {
            name = pName;
            password = pPassword;
            secprof = pSecprof;
        }

        public string GetName()
        {
            return name;
        }        
        public Security_profile GetSecurity_Profile()
        {
            return secprof;
        }
        public string GetPassword()
        {
            return password;
        }
        public void SetSecurityProfile(string pSec)
        {
            secprof = new Security_profile(pSec);
        }
    }
}
