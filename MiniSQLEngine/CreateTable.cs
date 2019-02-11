using System;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for CreateTable
/// </summary>
/// 
namespace MiniSQLEngine
{
    public class CreateTable
    {
        public Match createTable(string query)
        {
            string regExp = @"CREATE\s+TABLE\s+(\w+)\s+\(([^()]*)\);";
            //string input = "CREATE TABLE tabla (name string, edad int)";
            Match match = Regex.Match(query, regExp);
            return match;
        }
    }
}
