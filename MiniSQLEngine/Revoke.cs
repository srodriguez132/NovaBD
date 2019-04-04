using System.Collections.Generic;

namespace MiniSQLEngine
{
    public class Revoke : MiniSQL
    {
        private string privilegeType;
        private string table;
        private string securityProfile;

        public Revoke(string pPrivilegeType, string pTable, string pSecurityProfile)
        {
            privilegeType = pPrivilegeType;
            table = pTable;
            securityProfile = pSecurityProfile;
        }

        public override string Execute(Database pDatabase)
        {
            if(pDatabase.SecurityProfileExists(pDatabase.GetName()))
            {
                pDatabase.GetSecurityProfile(securityProfile).Revoke(privilegeType, table);
                return Messages.SecurityPrivilegeRevoked;
            }
            else
            {
                return Messages.SecurityProfileDoesNotExist;
            }

            
            
        }
    }
}