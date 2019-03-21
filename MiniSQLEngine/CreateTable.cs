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
            
          
            if(pDatabase.GetTable(name) == null)
            {
                pDatabase.CreateTable(name, atributes);
                if (pDatabase.GetTable(name).getCorrect() == false)
                {
                    pDatabase.DeleteTable(name);

                    return Messages.IncorrectDataType;
                }
                string path = @"..\..\..\DB\" + pDatabase.GetName()+ @"\" + name + ".txt";
                using (StreamWriter writer = File.CreateText(path))
                {
                    writer.WriteLine(name);
                    writer.WriteLine(atributes);
                }
                    return Messages.CreateTableSuccess;
            }
            else
            {
                return Messages.TableAlreadyExists;
            }
            
        }
    }
}
