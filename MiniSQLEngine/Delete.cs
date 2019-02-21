using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Databases;

namespace MiniSQLEngine
{
    public class Delete : MiniSQL 
    {
        public string name;
        public string condition;

        public Match delete(string query)
        {
            string regExp = @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+)\s+=\s+(\w+);";
            Match match = Regex.Match(query, regExp);

            name = (string)match.Groups[1].Value;
            condition = (string)match.Groups[2].Value;

            return match;
           

        }

        public string Execute(Database pDatabase)
        {
            Table tabla =  
            tabla.delete(condition);
            return Constants.DeleteMessage;
        }
    }

    
}
