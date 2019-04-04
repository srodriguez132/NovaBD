namespace MiniSQLEngine
{
    public class DropSecurity : MiniSQL
    {  
        public string profileName;

        public DropSecurity(string pProfileName)
        {
            profileName = pProfileName;
        }
        public override string Execute(Database pDatabase)
        {
            if(pDatabase.SecurityProfileExists(profileName))
            {
                pDatabase.DropSecurityProfile(profileName);
                return Messages.SecurityProfileDeleted;
            }
            return Messages.SecurityProfileDoesNotExist;
        }
    }
}