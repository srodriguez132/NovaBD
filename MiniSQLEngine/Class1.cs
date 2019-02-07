using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class CreateDropDatabase
{
	public CreateDataBase()
	{
        string input = "aaaaaaaaaaa CREATE DATABASE novaBD;";
        string regExp = @"CREATE\s+DATABASE\s+(\w +);";
        Match match = Regex.Match(input,regExp);
    }
    public DropDatabase()
    {
        string input = "aaaaaaaaaaa DROP DATABASE novaBD;";
        string regExp = @"DROP\s+DATABASE\s+(\w +);";
        Match match = Regex.Match(input, regExp);
    }
    public DropTable()
    {
        string input = "aaaaaaaaaaa DROP TABLE novaBD;";
        string regExp = @"DROP\s+TABLE\s+(\w +);";
        Match match = Regex.Match(input, regExp);
    }
}
