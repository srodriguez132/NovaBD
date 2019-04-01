using System;
using System.Collections.Generic;

namespace MiniSQLEngine
{
    public class Grant : MiniSQL
    {
        private string privilegeType;
        private string table;
        private string securityProfileName;

        public Grant(string pPrivilegeType, string pTable, string pSecurityProfileName)
        {
            privilegeType = pPrivilegeType;
            table = pTable;
            securityProfileName = pSecurityProfileName;
        }
        public override string Execute(Database pDatabase)
        {

            if (pDatabase.SecurityProfileExists(pDatabase.GetName()))
            {
                pDatabase.GetSecurityProfile(securityProfileName).Grant(privilegeType, table);
                return Messages.SecurityPrivilegeGranted;
            }
            else
            {
                return Messages.SecurityProfileDoesNotExist;
            }

        }
    }
}