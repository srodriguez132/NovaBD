namespace MiniSQLEngine
{
    internal class DeleteUser : MiniSQL
    {
        public string user;
      

        public DeleteUser(string pUser)
        {
           user = pUser;
            
        }

        public override string Execute(Database pDatabase)
        {
            return "";
        }
    }
}