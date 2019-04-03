using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class PrivilegeError : MiniSQL
    {
        public PrivilegeError()
        {
        }
        public override string Execute(Database pDatabase)
        {

            return Messages.SecurityNotSufficientPrivileges;
        }
    }
}

