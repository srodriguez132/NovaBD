using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MiniSQLEngine
{
    public class Insert : MiniSQL
    {
        public string name;
        public string column;
        public string value;

        public Match InsertInto(string query)
        {
            //INSERT INTO table_name (column1,column2) VALUES (value1, value2);
            //INSERT INTO table (column) VALUES (value);

            string regexp = @"INSERT\s+INTO\s+(\w+)\s+\(([\w=,]+)\)\s+VALUES\s+\(([\w,]+)\);";
            Match match = Regex.Match(query, regexp);

            name = (string)match.Groups[1].Value;
            column = (string)match.Groups[2].Value;
            value = (string)match.Groups[3].Value;

            return match;

        }

        public Insert()
        {
            //FALTA
        }

        public string Execute(Database pDatabase)
        {
            Table tabla = pDatabase.GetTable(name);
            tabla.setData(column, value );
            return Constants.InsertMessage;
        }
    }
}
