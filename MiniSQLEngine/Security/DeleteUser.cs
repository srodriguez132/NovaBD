namespace MiniSQLEngine
{
    public class DeleteUser : MiniSQL
    {
        public string name;
      

        public DeleteUser(string pName)
        {
           name = pName;
            
        }

        public override string Execute(Database pDatabase)
        {
            return pDatabase.DeleteUser(name);
        }
    }
}