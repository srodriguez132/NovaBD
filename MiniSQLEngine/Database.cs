﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace MiniSQLEngine
{
    class Database
    {
        private string name;

        //List<Table> tables = new List<Table>();


        public Database(string pName)
        {
            name=pName;
        }

        public static void CreateTable(string name, string definition)
        {
            //Table table = new Table();
            //tables.Add(table);
           
        }
    }
}
