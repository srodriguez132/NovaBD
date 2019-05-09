
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
        public string GetSuccess()
        {
            return "<Success/>";
        }
        public string GetError(string pError)
        {
            return "<Error>" + pError + "</Error>";
        }
        public string GetQuery(string pQuery)
        {
            string regExp = "<Query>(.*)</Query>";
            Match match = Regex.Match(pQuery, regExp);
            return match.Groups[1].Value;
        }
        public string AddAnswer(string pData)
        {
            string res = "<Answer>\n<Columns>\n";
            string regExp = "{([^}]*)}";
            Match match = Regex.Match(pData, regExp);
            string[] columns = match.Groups[1].Value.Split(',');
            for(int i = 0; i < columns.Length; i++)
            {
                res += "<Column>" + columns[i] + "</Columns>";
            }
            if(match.Length > 1)
            {

            }
            return res;
        }
    }
}
