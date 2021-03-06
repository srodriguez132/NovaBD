﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
namespace MiniSQLEngine
{
    public class CreateDataBase:MiniSQL
    {
        string dbName;
        public CreateDataBase(string dbName)
        {
            this.dbName = dbName;
        }
        public override string Execute(Database pDatabase)
        {
            pDatabase = new Database(dbName);

            //return Constants.CreateDatabaseMessage;
            return Messages.CreateDatabaseSuccess;
        }
    }
}
