namespace MiniSQLEngine
{
    internal class Revoke : MiniSQL
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
            return "";
        }
    }
}