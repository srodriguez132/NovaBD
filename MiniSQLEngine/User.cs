using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class User
    {
        private string name;
        private string password;
        private Security_profile secprof;

        public User (string pName, string pPassword, string pSecprof)
        {
            name = pName;
            password = pPassword;
            secporf = pSecprof;
        }

        public string GetName()
        {
            return name;
        }
        
        public Security_profile GetSecurity_Profile()
        {
            return secprof;
        }

        public void DefaultSecurityProfile()
        {
        }

    }
}
