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
        public string name;
        public string disk;

        public Match BackupDtb(string query)
        {
            string regularExp = @"BACKUP DATABASE\s+(\w+)\s+TO DISK = ('\w+');";
            
            Match match = Regex.Match(query, regularExp);
            
            return match;
        }
        
        public BackupDatabase(string pName, string pDisk)
        {
            name = pName;
            disk = pDisk;
        }

        public string Execute(Database pDatabase)
        {
            //FALTA
            return Constants.BackupDatabaseMessage;
        }
    } 
}
