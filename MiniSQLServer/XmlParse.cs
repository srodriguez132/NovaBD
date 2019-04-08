using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLServer
{
    class XmlParse
    {
        public XmlParse()
        {

        }
        public string[] GetData(string pData)
        {
            string regExp = "<Open Database = \"(\\w+)\" User = \"(\\w+)\" Password = \"(\\w+)\"/>";
            Match match = Regex.Match(pData, regExp);
            string[] data = new string[3];
            data[0] = match.Groups[1].Value;
            data[1] = match.Groups[2].Value;
            data[2] = match.Groups[3].Value;
            return data;
        }
    }
}
