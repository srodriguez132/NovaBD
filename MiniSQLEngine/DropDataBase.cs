using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{
    public class DropDataBase
    {
        public Match DropDatabase(string query)
        {
            string regExp = @"DROP\s+DATABASE\s+(\w+);";
            Match match = Regex.Match(query, regExp);
            return match;
        }
    }
}
