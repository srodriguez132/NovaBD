﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Database
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
        public string delete(string pCondition)
        {
            string regExp = @"(\w+)\s+(<|=|>)\s+(\w+)";
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
            string regExp = @"(\w+)\s+(<|=|>)\s+(\w+)";
            Match match = Regex.Match(pCondition, regExp);
            string column = match.Groups[1].Value;
            string sign = match.Groups[2].Value;
            string value = match.Groups[3].Value;
            string[] at = pUpdate.Split(',');
            string regExp1 = @"(\w+)\s";
            Match match1;
            int i = 0;
            int[] array = new int[at.Length - 1];
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
                match1 = Regex.Match(at[a+1], regExp1);
                while( k < columns.Length && f1==false)
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
            }
            if (sign.Equals("="))
            {
                for (int j = 0; j < datas.Count; j++)
                {
                    if (datas.ElementAt(j)[i] == value)
                    {
                        for (int z = 0; z < array.Length; z++)
                        {
                            for (int x = 0; x < at.Length; x++)
                            {
                                match1 = Regex.Match(at[x], regExp1);
                                datas.ElementAt(j)[z] = match1.Groups[2].Value;
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
                                match1 = Regex.Match(at[x], regExp1);
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
                                match1 = Regex.Match(at[x], regExp1);
                                datas.ElementAt(j)[z] = match1.Groups[2].Value;
                            }
                        }
                        count++;
                    }
                }
            }
            return count + "row(s) have been updated";
        }
    }
}
