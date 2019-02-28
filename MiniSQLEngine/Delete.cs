using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace MiniSQLEngine
{
    public class Delete : MiniSQL 
    {
        public string name;
        public string condition;

        public Delete(string pName, string pCondition)
        {
            name = pName;
            condition = pCondition;
        }

        public string Execute(Database pDatabase)
        {
            Table tabla = pDatabase.GetTable(name);
            tabla.delete(condition);
            return Constants.DeleteMessage;
        }
    }

    
}
