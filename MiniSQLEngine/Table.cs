using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class Table
    {
        string name;
        string[] columns;
        List<string[]> datas;
        public Table(string pName, string pColumns)
        {
            name = pName;
            string[] at = pColumns.Split(',');
            string regExp = @"(\w+)\s";
            columns = new string[at.Length - 1];
            for (int i = 0; i < at.Length; i++)
            {
                Match match = Regex.Match(at[i], regExp);
                columns[i] = (string)match.Groups[1].Value;
            }
            datas = new List<string[]>();
        }
        public void setData(string pData)
        {
            string[] at = pData.Split(',');
            string regExp = @"(\w+)";
            string[] a = new string[at.Length - 1];
            for (int i = 0; i < at.Length; i++)
            {
                Match match = Regex.Match(at[i], regExp);
                a[i] = (string)match.Groups[1].Value;
            }
            datas.Add(a);
        }
    }
}
