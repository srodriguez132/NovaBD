using System;
using System.IO;
using System.Text.RegularExpressions;


/// <summary>
/// Summary description for CreateTable
/// </summary>
/// 
namespace MiniSQLEngine
{
    public class CreateTable : MiniSQL
    {
        public string name;
        public string atributes;

        public Match createTable(string query)
        {
            string regExp = @"CREATE\s+TABLE\s+(\w+)\s+\(([^()]*)\);";
            //string input = "CREATE TABLE tabla (name string, edad int)";
            Match match = Regex.Match(query, regExp);
           // if (match.Success)
           // {
             //   string fileName = match.Groups[1].Value;
             //   string attributes = match.Groups[2].Value;
              //  string path = @"C:\Users\docencia\Desktop\";
              //  using (StreamWriter writer = File.CreateText(path + fileName + ".txt"))
              //  {
              //      writer.WriteLine(fileName + ";");
              //      writer.Write(attributes + ";");

              //  }
          //  }

            name = (string)match.Groups[1].Value;
            atributes = (string)match.Groups[2].Value;

            return match;
        }

        public string Execute(Database pDatabase)
        {
            pDatabase.CreateTable(name, atributes);
            return Constants.CreateTableMenssage;
        }
    }
}
