using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class RegularExpressions
    {
        public const string BackupDatabase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK = ('\w+');";
        public const string CreateDataBase = @"CREATE\s+DATABASE\s+(\w+);";
        public const string CreateTable = @"CREATE\s+TABLE\s+(\w+)\s+\(([^()]*)\);";
        public const string Delete = @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+[<|=|>].+);";
        public const string DropDataBase = @"DROP\s+DATABASE\s+(\w+);";
        public const string DropTable = @"DROP\s+TABLE\s+(\w+);";
        public const string Insert = @"INSERT\s+INTO\s+(\w+)(?:|\s+\(([\w=,]+)\))\s+VALUES\s+\((.+)\);";
        public const string Select = @"SELECT\s+(.*)\s+FROM\s+(\w+)(?:|\s+WHERE\s+(\w+[<|=|>].+));";
        public const string Update = @"UPDATE\s+(\w+)\s+SET\s+(.+)\s+WHERE\s+(.+);";
        public const string CreateSecurity = @"CREATE\s+SECURITY\s+PROFILE\s+(\w+);";
        public const string DropSecurity = @"DROP\s+SECURITY\s+PROFILE\s+(\w+);";
        public const string Grant = @"GRANT\s+(\w+)\s+ON\s+(\w+)\s+TO\s+(\w+);";
        public const string Revoke = @"REVOKE\s+(\w+)\s+ON\s+(\w+)\s+TO\s+(\w+);";
        public const string AddUser = @"ADD\s+USER\s+\('(\w+)','(\w+)',(\w+)\);";
        public const string DeleteUser = @"DELETE\s+USER\s+(\w+);";
    }
}
