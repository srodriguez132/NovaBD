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
        Boolean correct = true;
        public Table(string pName, string pColumns)
        {
            name = pName;
            string regExp = @"(\w+)(\s)(\w+)";
            string[] at = pColumns.Split(',');
            columns = new string[at.Length];
            condition = new string[at.Length];
            Boolean wrong = false;
            int i = 0;
            while(wrong == false && i<at.Length)
            {
                Match match = Regex.Match(at[i], regExp);
                columns[i] = match.Groups[1].Value;
                if (match.Groups[3].Value.Equals("TEXT")|| match.Groups[3].Value.Equals("INT") || match.Groups[3].Value.Equals("DOUBLE"))
                {
                    condition[i] = match.Groups[3].Value;
                    i++;
                }
                else
                {
                    columns = null;
                    condition = null;
                    correct = false;
                    wrong = true;
                }
                
            }
            datas = new List<string[]>();
        }
        public string getName()
        {
            return this.name;
        }
        public Boolean getCorrect()
        {
            return correct;
        }

        public string insert(string pData, string pColumns)
        {
            string[] at = pColumns.Split(',');
            string[] at1 = pData.Split(',');
            string[] at2 = new string[at1.Length];
            string[] res = new string[columns.Length];
            int[] a;
            string regexp = @"'(.+)'";
            for(int i=0; i < at1.Length; i++)
            {
                Match match = Regex.Match(at1[i], regexp);
                if (match.Success) { at2[i] = (string)match.Groups[1].Value; }
                else { at2[i] = at1[i]; }
              

            }
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
                res[a[k]] = at2[k];
            }
            datas.Add(res);
            return "Row inserted";
        }
        public int delete(string pCondition)
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
            return count;

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
            // Busca la posicion de la columna de la condicion de la base de datos
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
                    if (columns[k].Equals(match1.Groups[1].Value))
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
                                datas.ElementAt(j)[array[z]] = match1.Groups[3].Value;
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
                                datas.ElementAt(j)[i] = match1.Groups[2].Value;
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
                                datas.ElementAt(j)[i] = match1.Groups[2].Value;
                            }
                        }
                        count++;
                    }
                }
            }
            return count + " ";
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
                            if (pColumns.Equals("*"))
                            {
                                ret += "{";
                                for (int k = 0; k < columns.Length - 1; k++)
                                {
                                    ret += datas.ElementAt(j)[k] + ",";
                                }
                                
                                ret += datas.ElementAt(j)[columns.Length-1] + "}";
                            }
                            else { 
                            ret += "{";
                            for (int k = 0; k < at.Length; k++)
                            {
                                for (int z = 0; z < columns.Length; z++)
                                {
                                    if (at[k].Equals(columns[z]))
                                    {
                                        ret +=datas.ElementAt(j)[z] ;
                                    }                                
                                }
                                if(k+1 != at.Length) { ret += ","; }
                            }
                            ret += "}";
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
                            if (pColumns.Equals("*"))
                            {
                                ret += "{";
                                for (int k = 0; k < columns.Length - 1; k++)
                                {
                                    ret += datas.ElementAt(j)[k] + ",";
                                }

                                ret += datas.ElementAt(j)[columns.Length - 1] + "}";
                            }
                            else
                            {
                                ret += "{";
                                for (int k = 0; k < at.Length; k++)
                                {
                                    for (int z = 0; z < columns.Length; z++)
                                    {
                                        if (at[k].Equals(columns[z]))
                                        {
                                            ret += datas.ElementAt(j)[z];
                                        }
                                    }
                                    if (k + 1 != at.Length) { ret += ","; }
                                }
                                ret += "}";
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
                            if (pColumns.Equals("*"))
                            {
                                ret += "{";
                                for (int k = 0; k < columns.Length - 1; k++)
                                {
                                    ret += datas.ElementAt(j)[k] + ",";
                                }

                                ret += datas.ElementAt(j)[columns.Length - 1] + "}";
                            }
                            else
                            {
                                ret += "{";
                                for (int k = 0; k < at.Length; k++)
                                {
                                    for (int z = 0; z < columns.Length; z++)
                                    {
                                        if (at[k].Equals(columns[z]))
                                        {
                                            ret += datas.ElementAt(j)[z];
                                        }
                                    }
                                    if (k + 1 != at.Length) { ret += ","; }
                                }
                                ret += "}";
                            }
                        }
                    }
                }
            }
            else
            {
                for (int k = 0; k < datas.Count; k++)
                {
                    if (pColumns.Equals("*"))
                    {
                        ret += "{";
                        for (int p = 0; p < columns.Length - 1; p++)
                        {
                            ret += datas.ElementAt(k)[p] + ",";
                        }

                        ret += datas.ElementAt(k)[columns.Length - 1] + "}";
                    }
                    else
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
                            if (i + 1 != at.Length) { ret += ","; }
                        }
                        ret += "}";
                    }
                }               
            }
            return ret;
        }
    }
}

