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
            if (name.Equals("admin"))
            {
                return Messages.SecurityCantDeleteAdmin;
            }
            return pDatabase.DeleteUser(name);
        }
    }
}