using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Databases
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
        public string getName()
        {
            return name;
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
        public void delete(string pCondition)
        {
            string regExp = @"(\w+)\s+(<|=|>)\s+(\w+)";
            Match match = Regex.Match(pCondition, regExp);
            string column = match.Groups[1].Value;
            string sign = match.Groups[2].Value;
            string value = match.Groups[3].Value;
            int i = 0;
            Boolean f = false;
            while (i < columns.Length && f == false)
            {
                if (columns[i].Equals(column))
                {
                    f = true;
                }
                else
                {
                    i++;
                }
            }
            if (sign.Equals("="))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (datas.ElementAt(j)[i] == value)
                    {
                        datas.RemoveAt(j);
                        j--;
                    }
                }
            }
            else if (sign.Equals("<"))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) < Double.Parse(value))
                    {
                        datas.RemoveAt(j);
                        j--;
                    }
                }
            }
            else
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) > Double.Parse(value))
                    {
                        datas.RemoveAt(j);
                        j--;
                    }
                }
            }

        }
        public void update(string pUpdate, string pCondition)
        {
            string regExp = @"(\w+)\s+(<|=|>)\s+(\w+)";
            Match match = Regex.Match(pCondition, regExp);
            string column = match.Groups[1].Value;
            string sign = match.Groups[2].Value;
            string value = match.Groups[3].Value;
            int i = 0;
            Boolean f = false;
            while (i < columns.Length && f == false)
            {
                if (columns[i].Equals(column))
                {
                    f = true;
                }
                else
                {
                    i++;
                }
            }
            if (sign.Equals("="))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (datas.ElementAt(j)[i] == value)
                    {

                    }
                }
            }
            else if (sign.Equals("<"))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) < Double.Parse(value))
                    {

                    }
                }
            }
            else
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) > Double.Parse(value))
                    {

                    }
                }
            }
        }
        public string select(string pColumns, string pCondition)
        {
            string ret = null;
            string[] at = pColumns.Split(',');
            string[] array = new string[at.Length - 1];
            string regExp = @"(\w+)\s+(<|=|>)\s+(\w+)";
            Match match = Regex.Match(pCondition, regExp);
            Boolean f = false;
            int i = 0;
            while (i < columns.Length && f == false)
            {
                if (columns[i] == (string)match.Groups[1].Value) { f = true; }
                else { i++; }
            }
            if ((string)match.Groups[2].Value == "<")
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) < Double.Parse((string)match.Groups[3].Value))
                    {
                        for (int k = 0; k < at.Length; k++)
                        {
                            for (int z = 0; z < columns.Length; z++)
                            {
                                if (at[k].Equals(columns[z]))
                                {
                                    ret += datas.ElementAt(j)[z];
                                }
                            }
                        }
                    }
                }
            }
            else if ((string)match.Groups[2].Value == "=")
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) == Double.Parse((string)match.Groups[3].Value))
                    {
                        for (int k = 0; k < at.Length; k++)
                        {
                            for (int z = 0; z < columns.Length; z++)
                            {
                                if (at[k].Equals(columns[z]))
                                {
                                    ret += datas.ElementAt(j)[z];
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) > Double.Parse((string)match.Groups[3].Value))
                    {
                        for (int k = 0; k < at.Length; k++)
                        {
                            for (int z = 0; z < columns.Length; z++)
                            {
                                if (at[k].Equals(columns[z]))
                                {
                                    ret += datas.ElementAt(j)[z];
                                }
                            }
                        }
                    }
                }
            }
            return ret;
        }
    }
}
