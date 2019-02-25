using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{
    public class DropDataBase:MiniSQL
    {
        public string dbName;
        public DropDataBase(string dbName)
        {
            this.dbName = dbName;
        }
        public Match DropDatabase(string query)
        {
            string regExp = @"DROP\s+DATABASE\s+(\w+);";
            Match match = Regex.Match(query, regExp);
            return match;
        }

        public string Execute(Database pDatabase)
        {
            //pDatabase = new Database(dbName);
            return Constants.DropDatabaseMessage;
        }
    }
}
