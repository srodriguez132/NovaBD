using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;


namespace Databases
{
    public class Database
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


            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].getName().Equals(name))
                {
                    tables[i].delete(null);

                }
            }
        }
        public Table SearchTable(string pName)
            {
        
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].getName().Equals(name))
                {

                    return tables[i];
                }
            }
            return null;
        }
    }

        }
        
    }
}
