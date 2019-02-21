using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Database
{
    class Database
    {
        private string name;
        List<Table> tables = new List<Table>();

        public Database(string pName)
        {
            name = pName;

        }

        public void CreateTable(string name, string pColumns)
        {
            Table table = new Table(name, pColumns);
            tables.Add(table);
        }

        public void DeleteTable(string name)
        {

        }
        //parse
    }
}
