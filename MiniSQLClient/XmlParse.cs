﻿using System;
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
            string res = "";
            string Success = @"<Success/>";
            string Error = @"<Error>(\w+)</Error>";
            string Answer = @"<Answer>(\.+)</Answer>";
            string Columns = @"<Columns>(\.+)</Columns>";
            string Rows = @"<Rows>(\.+)</Rows>";
            string Column = @"<Column>(\w+)</Column>";
            string Row = @"<Row>(\.+)</Row>";
            string Value = @"<Value>(\w+)</Value>";
            string Close = @"<Colse/>";
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
                match = Regex.Match(query, Columns);
                if (match.Success)
                {
                    string[] at = match.Groups[1].Value.Split('\n');
                    res = "{";
                    for (int i = 0; i < at.Length - 1; i++)
                    {
                        match = Regex.Match(at[i], Column);
                        res += match.Groups[1].Value + ",";
                    }
                    match = Regex.Match(at[at.Length], Column);
                    res += match.Groups[1].Value + "}";
                }
                match = Regex.Match(query, Rows);
                if (match.Success)
                {
                    match = Regex.Match(query, Row);
                    if (match.Success)
                    {
                        string[] at = match.Groups[1].Value.Split('\n');
                        res += "{";
                        for (int i = 0; i < at.Length - 1; i++)
                        {
                            match = Regex.Match(at[i], Value);
                            res += match.Groups[1].Value + ",";
                        }
                        match = Regex.Match(at[at.Length], Value);
                        res += match.Groups[1].Value + "}";
                    }
                }
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
