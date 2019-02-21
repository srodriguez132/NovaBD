using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
   public class Update
    {
        public Match update(String query)
        {
            //UPDATE table SET column1=value1, column2=value2 WHERE condition;
            //UPDATE table SET column=value WHERE condition;

            string regexp = @"UPDATE\s+(\w+)\s+SET\s+([\w=,]+)\s+WHERE\s+(\w+);";
            Match match = Regex.Match(query, regexp);
            return match;
        }
    }
}
