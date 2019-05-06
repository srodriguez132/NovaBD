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
            string res = "<Answer>\n";
            string regExp = "{([^}]*)}";
            Match match = Regex.Match(pData, regExp);
            string regExpError = "ERROR:(.*)";
            Match match1 = Regex.Match(pData, regExpError);
            if (match.Success)
            {
                res += "<Columns>\n";
                string[] columns = match.Groups[1].Value.Split(',');
                for (int i = 0; i < columns.Length; i++)
                {
                    res += "<Column>" + columns[i] + "</Column>\n";
                }
                res += "</Columns>\n";
                if (match.Length >= 2)
                {
                    res += "<Rows>\n";

                    for (int j = 2; j < match.Length; j++)
                    {
                        string[] rows = match.Groups[j].Value.Split(',');
                        for (int i = 0; i < columns.Length; i++)
                        {
                            res += "<Row>" + columns[i] + "</Row>\n";
                        }
                    }
                    res += "</Rows>\n";
                }
            }

        
            else if(match1.Success)
            {
                res += "<Error>" + match1.Groups[1].Value + "</Error>\n";
            }
            else
            {
                res += pData;
            }
            res += "</Answer>";
            return res;
        }
    }
}
