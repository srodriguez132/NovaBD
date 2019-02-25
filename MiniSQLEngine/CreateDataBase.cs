using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace MiniSQLEngine
{
    public class CreateDataBase:MiniSQL
    {
        string dbName;
        public CreateDataBase(string dbName)
        {
            this.dbName = dbName;
        }

        public string resultado;
        public Match CreateDatabase(string query)
        {
            string regExp = @"CREATE\s+DATABASE\s+(\w+);";
            Match match = Regex.Match(query, regExp);
            resultado = (string)match.Groups[1].Value;
            return match;
        }

        public string Execute()
        {
            Database pDatabase = new Database(dbName);
            return Constants.CreateDatabaseMessage;
        }
    }
}
