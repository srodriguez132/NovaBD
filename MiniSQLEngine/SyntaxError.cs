using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class SyntaxError : MiniSQL
    {
        public SyntaxError()
        {
        }
        public override string Execute(Database pDatabase)
        {
            return Messages.WrongSyntax;
        }
    }
}
