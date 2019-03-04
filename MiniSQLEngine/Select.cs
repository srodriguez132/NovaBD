﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class Select : MiniSQL
    {
        public string columns;
        public string table;
        public string condition;
        public Select (string columns, string table, string condition)
        {
            this.columns = columns;
            this.table = table;
            this.condition = condition;
        }
        public override string Execute(Database pDatabase)
        {
            Table pTable = pDatabase.GetTable(table);
            return pTable.select(columns, condition);
           
        }
        

    }
}
    