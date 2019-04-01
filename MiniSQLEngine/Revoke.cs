using System.Collections.Generic;

namespace MiniSQLEngine
{
    internal class Revoke : MiniSQL
    {
        private string privilegeType;
        private string table;
        private Security_profile securityProfile;

        public Revoke(string pPrivilegeType, string pTable, Security_profile pSecurityProfile)
        {
            privilegeType = pPrivilegeType;
            table = pTable;
            securityProfile = pSecurityProfile;
        }

        public override string Execute(Database pDatabase)
        {
            if(pDatabase.SecurityProfileExists(pDatabase.GetName()))
            {
                securityProfile.Revoke(privilegeType, table);
                return Messages.SecurityPrivilegeRevoked;
            }
            else
            {
                return Messages.SecurityProfileDoesNotExist;
            }

            
            
        }
    }
}