using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace MiniSQLDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @".\";
            Console.WriteLine("Write the name of the file you want to read ");
            string inputfile = Console.ReadLine();
            string res = null;
            Database db = null;
            CreateDataBase create = null;
            try
            {
                using (StreamWriter writer = File.CreateText(path + "output.txt"))
                {
                    int c = 1;
                    Stopwatch stopWatch = new Stopwatch();
                    //    Database db = new Database("database1");
                    writer.WriteLine("# TEST " + c);

                    string[] lines = System.IO.File.ReadAllLines(@"..\..\..\Inputs\" + inputfile + ".txt");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        stopWatch.Start();
                        if (lines[i] == "")
                        {
                            stopWatch.Stop();
                            writer.WriteLine("TOTAL TIME: " + Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds) + "s");
                            stopWatch = new Stopwatch();
                            if (db != null)
                            {
                                db.Dispose();
                            }
                            stopWatch.Start();
                            c++;
                            //db = new Database("database" + i);
                            writer.WriteLine("");
                            writer.WriteLine("# TEST " + c);
                        }
                        else
                        {
                            Stopwatch stopWatch1 = new Stopwatch();
                            stopWatch1.Start();
                            Match match = Regex.Match(lines[i], @"(\w+),(\w+),(\w+)");
                            if (match.Success)
                            {
                                create = new CreateDataBase(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                                res = create.Execute(db);
                                db = create.getDatabase();
                            }
                            else
                            {
                                res = db.Query(lines[i]);
                            }
                            stopWatch1.Stop();
                            writer.WriteLine(res + " (" + Convert.ToDecimal(stopWatch1.Elapsed.TotalSeconds) + "s)");
                        }
                    }
                    stopWatch.Stop();
                    writer.WriteLine("TOTAL TIME: " + Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds) + "s");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("The file doesn´t exist ");
                //The program stops for 5 seconds
                Thread.Sleep(5000);

            }
        }
    }
}
