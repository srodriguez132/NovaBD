namespace MiniSQLEngine
{
    public class Grant : MiniSQL
    {
        private string privilegeType;
        private string table;
        private string securityProfile;

        public Grant(string pPrivilegeType, string pTable, string pSecurityProfile)
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