using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    public class Table
    {
        string name;
        string[] columns;
        string[] condition;
        List<string[]> datas;
        public Table(string pName, string pColumns)
        {
            name = pName;
            string regExp = @"(\w+)(\s)(\w+)";
            string[] at = pColumns.Split(',');
            columns = new string[at.Length];
            condition = new string[at.Length];

            for (int i = 0; i < at.Length; i++)
            {
                Match match = Regex.Match(at[i], regExp);
                columns[i] = match.Groups[1].Value;
                condition[i] = match.Groups[3].Value;
            }
            datas = new List<string[]>();
        }
        public string getName()
        {
            return this.name;
        }


        public string insert(string pData, string pColumns)
        {
            string[] at = pColumns.Split(',');
            string[] at1 = pData.Split(',');
            string[] res = new string[columns.Length];
            int[] a;
            if (pColumns != "")
            {
                a = new int[at.Length];
                for (int i = 0; i < at.Length; i++)
                {
                    for (int j = 0; j < columns.Length; j++)
                    {
                        if (at[i] == columns[j])
                        {
                            a[i] = j;
                        }
                    }
                }
            }
            else
            {
                a = new int[columns.Length];
                for (int j = 0; j < columns.Length; j++)
                {

                    a[j] = j;

                }
            }
            for (int k = 0; k < a.Length; k++)
            {
                res[a[k]] = at1[k];
            }
            datas.Add(res);
            return "Row inserted";
        }
        public string delete(string pCondition)
        {
            string regExp = @"(\w+)(<|=|>)(\w+)";
            Match match = Regex.Match(pCondition, regExp);
            string column = match.Groups[1].Value;
            string sign = match.Groups[2].Value;
            string value = match.Groups[3].Value;
            int i = 0;
            int count = 0;
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
                        count++;
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
                        count++;
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
                        count++;
                    }
                }
            }
            return count + "row(s) have been deleted";

        }
        public string update(string pUpdate, string pCondition)
        {
            string regExp = @"(\w+)(<|=|>)(\w+)";
            Match match = Regex.Match(pCondition, regExp);
            string column = match.Groups[1].Value;
            string sign = match.Groups[2].Value;
            string value = match.Groups[3].Value;
            string[] at = pUpdate.Split(',');
            Match match1;
            int i = 0;
            int[] array = new int[at.Length];
            int count = 0;
            Boolean f = false;
            Boolean f1 = false;
            int a = 0;
            int k = 0;
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
            while (a < at.Length)
            {
                match1 = Regex.Match(at[a], regExp);
                while (k < columns.Length && f1 == false)
                {
                    if (columns[k].Equals(column))
                    {

                        array[a] = k;
                        f1 = true;
                    }
                    else
                    {
                        k++;
                    }
                }
                a++;
            }
            if (sign.Equals("="))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (datas.ElementAt(j)[i].Equals(value))
                    {
                        for (int z = 0; z < array.Length; z++)
                        {
                            for (int x = 0; x < at.Length; x++)
                            {
                                match1 = Regex.Match(at[x], regExp);
                                datas.ElementAt(j)[z] = match1.Groups[3].Value;
                            }
                        }
                        count++;
                    }
                }
            }
            else if (sign.Equals("<"))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) < Double.Parse(value))
                    {
                        for (int z = 0; z < array.Length; z++)
                        {
                            for (int x = 0; x < at.Length; x++)
                            {
                                match1 = Regex.Match(at[x], regExp);
                                datas.ElementAt(j)[z] = match1.Groups[2].Value;
                            }
                        }
                        count++;
                    }
                }
            }
            else
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (Double.Parse(datas.ElementAt(j)[i]) > Double.Parse(value))
                    {
                        for (int z = 0; z < array.Length; z++)
                        {
                            for (int x = 0; x < at.Length; x++)
                            {
                                match1 = Regex.Match(at[x], regExp);
                                datas.ElementAt(j)[z] = match1.Groups[2].Value;
                            }
                        }
                        count++;
                    }
                }
            }
            return count + "row(s) have been updated";
        }
        public string select(string pColumns, string pCondition)
        {

            string ret = "{" + pColumns + "}";
            string[] at = pColumns.Split(',');
            string[] array = new string[at.Length];
            if (pCondition != "")
            {
                string regExp = @"(\w+)(<|=|>)(\w+)";
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
                                        ret += "{" + datas.ElementAt(j)[z] + "}";
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
                        if (datas.ElementAt(j)[i] == (string)match.Groups[3].Value)
                        {
                            for (int k = 0; k < at.Length; k++)
                            {
                                for (int z = 0; z < columns.Length; z++)
                                {
                                    if (at[k].Equals(columns[z]))
                                    {
                                        ret += "{" + datas.ElementAt(j)[z] + "}";
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
                                        ret += "{" + datas.ElementAt(j)[z] + "}";
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                for (int k = 0; k < datas.Count; k++)
                {
                    ret += "{";
                    for (int i = 0; i < at.Length; i++)
                    {
                        for (int j = 0; j < columns.Length; j++)
                        {
                            if (at[i] == columns[j])
                            {
                                ret += datas.ElementAt(k)[j];
                            }
                        }
                    }
                    ret += "}";
                }               
            }
            return ret;
        }
    }
}

