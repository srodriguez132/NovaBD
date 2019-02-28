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

        public CreateTable(string pName, string pAtributes)
        {
            name = pName;
            atributes = pAtributes;
        }

        public override string Execute(Database pDatabase)
        {
            pDatabase.CreateTable(name, atributes);
            return Constants.CreateTableMessage;
        }
    }
}
