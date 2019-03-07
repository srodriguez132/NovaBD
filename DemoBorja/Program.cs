using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace DemoBorja
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @"C:\Users\docencia\Downloads\";
            using (StreamWriter writer = File.CreateText(path + "output.txt"))
            {
                Database db = new Database("database1");
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\docencia\Downloads\TesterInput-example.txt");
                for (int i = 0; i < lines.Length; i++)
                {
                    string res = db.Query(lines[i]);
                    writer.WriteLine(res);
                }
            }

        }
    }
}
