﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MiniSQLEngine
{
  public abstract class MiniSQL
    {
        public abstract string Execute(Database pDatabase);
        
    }
}
