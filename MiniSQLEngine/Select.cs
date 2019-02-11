using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class Select
    {
        public Match delete(string query)
        {
            string regExp = @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+)=(\w+);";
            Match match = Regex.Match(query, regExp);
            return match;
        }

        public Match select(string query)
        {
            string regExp = @"SELECT\s+(\w+|\*)(\s+|\,\s+\w+\s+)FROM\s+(\w+)(\s+WHERE\s+(\w+)\s+=\s+(\w+);|;)";
            Match match = Regex.Match(query, regExp);
            return match;
        }
       
    }
}
    