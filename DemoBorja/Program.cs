using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MiniSQLEngine;

namespace DemoBorja
{
    class Program
    {
        static void Main(string[] args)
        {

            string path = @".\";
            Console.WriteLine("Write the name of the file you want to read ");
            string inputfile = Console.ReadLine();
            try
            {
                using (StreamWriter writer = File.CreateText(path + "output.txt"))
                {
                    int c = 1;
                    Stopwatch stopWatch = new Stopwatch();
                    Database db = new Database("database1");
                    writer.WriteLine("# TEST " + c);

                    string[] lines = System.IO.File.ReadAllLines(@".\Inputs\" + inputfile + ".txt");
                    for (int i = 0; i < lines.Length; i++)
                    {
                        stopWatch.Start();
                        if (lines[i] == "")
                        {
                            stopWatch.Stop();
                            writer.WriteLine("TOTAL TIME: " + Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds) + "s");
                            stopWatch = new Stopwatch();
                            stopWatch.Start();
                            c++;
                            db = new Database("database" + i);
                            writer.WriteLine("");
                            writer.WriteLine("# TEST " + c);
                        }
                        else
                        {
                            Stopwatch stopWatch1 = new Stopwatch();
                            stopWatch1.Start();
                            string res = db.Query(lines[i]);
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
                Console.WriteLine("The file doesn´t exist ");
                //The program stops for 5 seconds
                Thread.Sleep(5000);

            }
        }
    }
}
