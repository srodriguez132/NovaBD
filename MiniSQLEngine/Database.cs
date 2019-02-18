using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using MiniSQLEngine;

namespace MiniSQLEngine
{
    class Database
    {
        private string name;
        List<Table> tables = new List<Table>();


        public Database(string pName)
        {
            name = pName;
            
        }

        public void CreateTable(string name, string definition)
        {
          Table table = new Table(name, definition);
          tables.Add(table);
        }
        //parse
    }
}
