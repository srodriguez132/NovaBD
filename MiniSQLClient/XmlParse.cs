using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLClient
{
    class XmlParse
    {
        string openDatabase;
        string query;
        public XmlParse()
        {
            openDatabase = "<Open Database =";
            query = "<Query>";
        }
        public void AddDatabase(string name)
        {
            openDatabase += "\"" + name + "\"";
        }
        public void AddUserName(string userName)
        {
            openDatabase += " User=" + "\"" + userName + "\"";
        }
        public void AddPasssword(string passName)
        {
            openDatabase += " Password=" + "\"" + passName + "\"/>";
        }
        public string GetOpenDatabase()
        {
            return openDatabase;
        }
        public void AddQuery(string queryName)
        {
            query += queryName + "</Query>";
        }
        public string GetQuery()
        {
            return query;
        }
        public string Parse(string query)
        {
            string Success = @"<Success/>";
            string Error = @"<Error>(\w+)</Error>";
            string Answer = @"<Answer>(\.+)</Answer>";
            string Columns = @"<Columns>(\.+)</Columns>";
            string Rows = @"<Rows>(\.+)</Rows>";
            string Column = @"<Column>(\w+)</Column>";
            Match match = Regex.Match(query,Success);
            return null;
        }
    }
}
