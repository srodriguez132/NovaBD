using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Demo
{
    public class Program
    {
        static void main(string[] args)
        {
            string input = "kjhflksahflsh SELECT* FROM table1 alkdfsj 34 j wejrl rwekj rwej SELECT column from table1";

           string regExp = @"SELECT\s + (\*)\s + FROM\s + (\w +)";
            Match match = Regex.Match(input, regExp);
            if (match.Success)
            {
                Console.WriteLine("Groups[0]= " + match.Groups[0].Value + "\n");
                Console.WriteLine("Groups[1]= " + match.Groups[1].Value + "\n");
                Console.WriteLine("Groups[2]= " + match.Groups[2].Value + "\n");
            }
            foreach(Match m in Regex.Matches(input, regExp))
            {
                Console.WriteLine("Groups[0]= " + m.Groups[0].Value + "\n");
                Console.WriteLine("Groups[1]= " + m.Groups[1].Value + "\n");
                Console.WriteLine("Groups[2]= " + m.Groups[2].Value + "\n");
            }
        }
        }
    }

