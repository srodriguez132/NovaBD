using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;



namespace MiniSQLEngine
{
    public class Delete : MiniSQL 
    {
        public string name;
        public string condition;

        public Delete(string pName, string pCondition)
        {
            name = pName;
            condition = pCondition;
        }

        public override string Execute(Database pDatabase)
        {
            Table tabla = pDatabase.GetTable(name);
            if (tabla == null || tabla.getCorrect() == false)
            {
                //return Constants.ErrorMessage;
                return Messages.TableDoesNotExist;
            }
            else
            {
                if(tabla.delete(condition) == 0)
                {
                    return Messages.ColumnDoesNotExist;
                }
                else
                { 
                    return Messages.TupleDeleteSuccess;
                }
                //return tabla.delete(condition) + Constants.DeleteMessage;
            }
        }
    }

    
}
