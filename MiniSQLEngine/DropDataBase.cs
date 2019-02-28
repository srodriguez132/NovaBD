using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{
    public class DropDataBase:MiniSQL
    {
        public string dbName;
        public DropDataBase(string dbName)
        {
            this.dbName = dbName;
        }    
        public string Execute(Database pDatabase)
        {
            //pDatabase = new Database(dbName);
            return Constants.DropDatabaseMessage;
        }
    }
}
