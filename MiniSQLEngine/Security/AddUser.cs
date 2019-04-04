namespace MiniSQLEngine
{
    public class AddUser : MiniSQL
    {
        private string user;
        private string password;
        private string securityProfile;

        public AddUser(string pUser, string pPassword, string pSecurityProfile)
        {
            user = pUser;
            password = pPassword;
            securityProfile = pSecurityProfile;
        }

        public override string Execute(Database pDatabase)
        {
            return pDatabase.AddUser(user, password, securityProfile);  
        }
    }
}