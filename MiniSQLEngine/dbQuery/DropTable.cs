using System;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{ 
public class DropTable : MiniSQL
{
        public string tableName;
        public DropTable(string tableName)
        {
            this.tableName = tableName;
        }
        public override string Execute(Database pDatabase)
        {      
            pDatabase.DeleteTable(tableName);
            return Messages.DropTableMessage;
            
    }
    }
}
