using System;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{ 
public class CreateDropTable
{
	public Match CreateDataBase(string query)
	{       
        string regExp = @"CREATE\s+DATABASE\s+(\w+);";
        Match match = Regex.Match(query,regExp);
        return match;
    }
    public Match DropDataBase(string query)
    {       
        string regExp = @"DROP\s+DATABASE\s+(\w+);";
        Match match = Regex.Match(query, regExp);
        return match;
    }
    public Match DropTable(string query)
    {
        string regExp = @"DROP\s+TABLE\s+(\w+);";
        Match match = Regex.Match(query, regExp);
        return match;
    }
}
}
