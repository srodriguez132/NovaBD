 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class Select : MiniSQL
    {
        public string columns;
        public string table;
        public string condition;
        public Select (string columns, string table, string condition)
        {
            this.columns = columns;
            this.table = table;
            this.condition = condition;
        }
        public Match select(string query)
        {
            string regExp = @"SELECT\s+(\w+|\*)\s+FROM\s+(\w+);|SELECT\s+(\w+|\*)\s+FROM\s+(\w+)\s+WHERE\s+(\w+[<|=|>]\w+);";
            Match match = Regex.Match(query, regExp);
            return match;
        }
        public string Execute (Database pDatabase)
        {
            Table pTable = pDatabase.GetTable(table);
            pTable.select(columns, condition);
            return Constants.SelectMessage;
        }
        

    }
}
    