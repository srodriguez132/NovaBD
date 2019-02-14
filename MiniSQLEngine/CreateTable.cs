using System;
using System.IO;
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
            if (match.Success)
            {
                string fileName = match.Groups[1].Value;
                string attributes = match.Groups[2].Value;
                string path = @"C:\Users\docencia\Desktop\";
                using (StreamWriter writer = File.CreateText(path + fileName + ".txt"))
                {
                    writer.WriteLine(fileName + ";");
                    writer.Write(attributes + ";");

                }
            }

            return match;

        }
    }
}
