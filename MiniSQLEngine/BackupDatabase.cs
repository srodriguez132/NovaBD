using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class BackupDatabase : MiniSQL
    {
        public Match BackupDtb(string query)
        {
            string regularExp = @"BACKUP DATABASE\s+(\w+)\s+TO DISK = ('\w+');";
            
            Match match = Regex.Match(query, regularExp);
            
            return match;
        }
        
        public BackupDatabase()
        {
            //FALTA
        }

        public string Execute(Database pDatabase)
        {

            return Constants.BackupDatabaseMessage;
        }
    } 
}
