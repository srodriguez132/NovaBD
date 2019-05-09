using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MiniSQLEngine;

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
        public void AddPassword(string passName)
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
            string res = "";
            string Success = @"<Success/>";
            string Error = @"<Error>(\w+)</Error>\n";
            string Answer = @"<Answer>(.+)</Answer>";          
            string Close = @"<Close/>";
            Match match = Regex.Match(query, Success);
            if (match.Success)
            {
                return Messages.OpenDatabaseSuccess;
            }
            match = Regex.Match(query, Error);
            if (match.Success)
            {
                return (string)match.Groups[1].Value;
            }
            match = Regex.Match(query, Answer);
            if (match.Success)
            {
                match = Regex.Match(query, Error);
                if (match.Success)
                {
                    return (string)match.Groups[1].Value;
                }
                match = Regex.Match(query, Answer);
                res += match.Groups[1].Value;               
                return res;
            }                               
            match = Regex.Match(query, Close);
            if (match.Success)
            {
                return "";
            }
            return null;
        }
    }
}
