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
        public CreateDataBase(string dbName,string pName,string pPass)
        {
            this.dbName = dbName;
            name = pName;
            pass = pPass;
        }
        public override string Execute(Database pDatabase)
        {
            pDatabase = new Database(dbName,name,pass);

            //return Constants.CreateDatabaseMessage;
            return Messages.CreateDatabaseSuccess;
        }
    }
}
