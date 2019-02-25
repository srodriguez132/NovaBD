using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class RegularExpressions
    {
        public const string BackupDatabase = @"BACKUP DATABASE\s+(\w+)\s+TO DISK = ('\w+');";
        public const string CreateDataBase = @"CREATE\s+DATABASE\s+(\w+);";
        public const string CreateTable = @"CREATE\s+TABLE\s+(\w+)\s+\(([^()]*)\);";
        public const string Delete = @"DELETE\s+FROM\s+(\w+)\s+WHERE\s+(\w+)\s+=\s+(\w+);";
        public const string DropDataBase = @"DROP\s+DATABASE\s+(\w+);";
        public const string DropTable = @"DROP\s+TABLE\s+(\w+);";
        public const string Insert = @"INSERT\s+INTO\s+(\w+)\s+\(([\w=,]+)\)\s+VALUES\s+\(([\w,]+)\);";
        public const string Select = @"SELECT\s+(\w+|\*)(\s+|\,\s+(\w+)\s+)FROM\s+(\w+)(\s+WHERE\s+(\w+)\s+=\s+(\w+);|;)";
        public const string Update = @"UPDATE\s+(\w+)\s+SET\s+([\w=,]+)\s+WHERE\s+(\w+);";
    }
}
