using System;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{ 
public class DropTable
{
    public Match Drop_Table(string query)
    {
        string regExp = @"DROP\s+TABLE\s+(\w+);";
        Match match = Regex.Match(query, regExp);
        return match;
    }
}
}
