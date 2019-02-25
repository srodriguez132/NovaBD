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

    public Match Drop_Table(string query)
    {
        string regExp = @"DROP\s+TABLE\s+(\w+);";
        Match match = Regex.Match(query, regExp);
        return match;
    }
    public string Execute(Database pDatabase)
    {
           
            pDatabase.DeleteTable(tableName);
            return Constants.DropTableMessage;
    }
    }
}
