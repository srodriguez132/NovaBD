namespace MiniSQLEngine
{
    public class CreateSecurity : MiniSQL
    {
        public string profile;

        public CreateSecurity(string pProfile)
        {
            profile = pProfile;
        }
        public override string Execute(Database pDatabase)
        {
            return "";
        }
    }
}