namespace MiniSQLEngine
{
    public class DropSecurity : MiniSQL
    {  
        public string profile;

        public DropSecurity(string pProfile)
        {
            profile = pProfile;
        }
        public override string Execute(Database pDatabase)
        {
            return "";
        }
    }
}