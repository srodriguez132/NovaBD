using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace MiniSQLEngine
{
    public class CreateDataBase:MiniSQL
    {
        string dbName;
        string name;
        string pass;
        Database db;
        public CreateDataBase(string dbName,string pName,string pPass)
        {
            this.dbName = dbName;
            name = pName;
            pass = pPass;
            db = new Database(dbName, name, pass);
        }
        public override string Execute(Database pDatabase)
        {
            string pathDatabases = @"..\..\..\DB\";
            string[] databases = System.IO.Directory.GetDirectories(pathDatabases);
            int j = 0;      
            while (j < databases.Length)
            {
                //Checks if database exists
                if (databases[j].Equals(pathDatabases + dbName))
                {

                    if (name == "admin" && pass == "admin")
                    {                                        
                        return Messages.OpenDatabaseSuccess;
                    }
                    else
                    {
                        if (db.GetUser(name) != null)
                        {
                            if (db.GetUser(name).GetName() == name && db.GetUser(name).GetPassword() == pass)
                            {
                                return MiniSQLEngine.Messages.OpenDatabaseSuccess;
                            }
                            else
                            {
                                return MiniSQLEngine.Messages.SecurityIncorrectLogin;
                            }
                        }
                        else
                        {
                            return MiniSQLEngine.Messages.SecurityIncorrectLogin;
                        }
                    }                  
                }
                j++;
            }

            if (name =="admin" && pass=="admin")
            {
                return MiniSQLEngine.Messages.CreateDatabaseSuccess;
            }
            else
            {
                return MiniSQLEngine.Messages.SecurityIncorrectLogin;
            }            
        }
        public Database getDatabase()
        {
            return db;
        }
    }

}
