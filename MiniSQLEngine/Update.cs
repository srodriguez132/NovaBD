using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
   public class Update : MiniSQL
    {
        public string tableName;
        public string updateInfo;
        public string condition;
        public Update(string tableName, string updateInfo, string condition)
        {
            this.tableName = tableName;
            this.updateInfo = updateInfo;
            this.condition = condition;
        }

        public override string Execute(Database pDatabase)
        {
            Table pTable = pDatabase.GetTable(tableName);
           return pTable.update(updateInfo, condition);
            
        }
    }
}
