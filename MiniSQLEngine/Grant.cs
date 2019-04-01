using System;
using System.Collections.Generic;

namespace MiniSQLEngine
{
    public class Grant : MiniSQL
    {
        private string privilegeType;
        private string table;
        private Security_profile securityProfile;

        public Grant(string pPrivilegeType, string pTable, Security_profile pSecurityProfile)
        {
            privilegeType = pPrivilegeType;
            table = pTable;
            securityProfile = pSecurityProfile;
        }
        public override string Execute(Database pDatabase)
        {
            Boolean encontrado = false;
            List<Security_profile> profiles = pDatabase.GetSecurity_Profiles();
            int i = 0;
            while(!encontrado && i <= pDatabase.GetSecurity_Profiles().Count)
            {
                if (profiles[i].Equals(securityProfile))
                {
                    profiles[i].Grant(privilegeType, table);
                    return Messages.SecurityPrivilegeGranted;
                }
                i++;
            }
            return Messages.SecurityProfileDoesNotExist;
        }
    }
}