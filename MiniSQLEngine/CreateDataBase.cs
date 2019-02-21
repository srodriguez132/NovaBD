using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Databases;
namespace MiniSQLEngine
{
    public class CreateDataBase
    {
        public string resultado;
        public Match CreateDatabase(string query)
        {
            string regExp = @"CREATE\s+DATABASE\s+(\w+);";
            Match match = Regex.Match(query, regExp);
            resultado = (string)match.Groups[1].Value;
            return match;
        }

        public string Execute(Database pDatabase)
        {
            pDatabase = new Database(resultado);
            return Constants.CreateDatabaseMessage;
        }
    }
}
