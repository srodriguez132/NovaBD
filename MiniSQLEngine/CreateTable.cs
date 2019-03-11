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
            if(atributes == "")
            {
                return Messages.WrongSyntax;
            }
            pDatabase.CreateTable(name, atributes);
            //return Constants.CreateTableMessage;
            if(pDatabase.GetTable(name).getCorrect() == false)
            {
                //pDatabase.DeleteTable(name);
                return Messages.IncorrectDataType;
            }
            return Messages.CreateTableSuccess;
        }
    }
}
