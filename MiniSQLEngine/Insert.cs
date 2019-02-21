using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MiniSQLEngine
{
    public class Insert
    {
        public Match InsertInto(string query)
        {
            //INSERT INTO table_name (column1,column2) VALUES (value1, value2);
            //INSERT INTO table (column) VALUES (value);

            string regexp = @"INSERT\s+INTO\s+(\w+)\s+\(([\w=,]+)\)\s+VALUES\s+\(([\w,]+)\);";
            Match match = Regex.Match(query, regexp);
            return match;

        }

       
    }
}
