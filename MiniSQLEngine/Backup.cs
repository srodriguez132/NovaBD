using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{
    class Backup
    {
        public static void backupCheck(string input)
        {
            string regExp = @"BACKUP DATABASE\s(\w+) TO DISK = ('\w+');";
            foreach (Match m in Regex.Matches(input, regExp))
            {
                Console.WriteLine("Groups[0]= " + m.Groups[0].Value + "\n");
                Console.WriteLine("Groups[1]= " + m.Groups[1].Value + "\n");
                Console.WriteLine("Groups[2]= " + m.Groups[2].Value + "\n");
            }
        }
}
}
