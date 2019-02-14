using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MiniSQLEngine
{
    class InsertIntoUpdate
    {
        public Match InsertInto(string query)
        {
            //INSERT INTO table_name (column1,column2) VALUES (value1, value2);
            //INSERT INTO table (column) VALUES (value);

            string regexp = @"INSERT\s+INTO\s+(\w+)\s+\(([\w=,]+)\)\s+VALUES\s+\(([\w,]+)\);";
            Match match = Regex.Match(query, regexp);
            return match;

        }

        public Match Update(string query)
        {
            //UPDATE table SET column1 = value1, column2 = value2 WHERE condition;
            //UPDATE table SET column = value WHERE condition;

            string regexp = @"UPDATE\s+(\w+)\s+SET\s+([\w=,]+)\s+WHERE\s+(\w+);";
            Match match = Regex.Match(query, regexp);
            return match;
        }
    }
}
