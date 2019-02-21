﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class BackupDatabase
    {
        public Match BackupDtb(string query)
        {
            string regularExp = @"BACKUP DATABASE\s+(\w+)\s+TO DISK = ('\w+');";
            
            Match match = Regex.Match(query, regularExp);
            
            return match;
        }

    }
}
