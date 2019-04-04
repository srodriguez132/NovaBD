namespace MiniSQLEngine
{
    public class CreateSecurity : MiniSQL
    {
        public string profileName;

        public CreateSecurity(string pProfileName)
        {
            profileName = pProfileName;
        }
        public override string Execute(Database pDatabase)
        {
            if (!pDatabase.SecurityProfileExists(profileName))
            {
                Security_profile secProfile = new Security_profile(profileName);
                pDatabase.GetSecurity_Profiles().Add(secProfile);
                return Messages.SecurityProfileCreated;
            }
            return Messages.SecurityProfileAlreadyExists;
        }
    }
}