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
        public Match select(string query)
        {
            string regExp = @"SELECT\s+(\w+|\*)\s+FROM\s+(\w+);|SELECT\s+(\w+|\*)\s+FROM\s+(\w+)\s+WHERE\s+(\w+[<|=|>]\w+);";
            Match match = Regex.Match(query, regExp);
            return match;
        }

        

    }
}
    