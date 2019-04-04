using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace MiniSQLEngine
{
    public class Insert : MiniSQL
    {
        public string name;
        public string columns;
        public string values;
       
        public Insert(string pName, string pColumns, string pValues)
        {
            name = pName;
            columns = pColumns;
            values = pValues;
        }

        public override string Execute(Database pDatabase)
        {
            Table tabla = pDatabase.GetTable(name);
            if (tabla == null || tabla.GetCorrect() == false)
            {
                //return Constants.ErrorMessage;
                return Messages.TableDoesNotExist;
            }
            else
            {
                tabla.Insert(values, columns);
                //return Constants.InsertMessage;
                return Messages.InsertSuccess;
            }
            
        }
    }
}
