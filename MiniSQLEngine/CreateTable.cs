using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for CreateTable
/// </summary>
public class CreateTable
{
	public CreateTable()
	{
        string regExp = @"CREATE\s+TABLE\s+(\w+)\s+\(([^()]*)\);";
        string input = "CREATE TABLE tabla (name string, edad int)";
        Match match = regExp.Match(regExp, input);
        if (match.Success)
        {

        }
    }
}
