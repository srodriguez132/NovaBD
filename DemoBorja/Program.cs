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

namespace DemoBorja
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
            string pathDatabases = @"..\..\..\DB\";
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
                            db.Dispose();
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
                                string[] databases = System.IO.Directory.GetDirectories(pathDatabases);
                                int j = 0;
                                Boolean f = false;
                                while(j < databases.Length && f == false)
                                {
                                    //Checks if database exists
                                    if (databases[j].Equals(pathDatabases + match.Groups[1].Value))
                                    {
                                        if(match.Groups[2].Value.Equals("admin") && match.Groups[3].Value.Equals("admin"))
                                        {
                                            db = new Database(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                                            writer.WriteLine(MiniSQLEngine.Messages.OpenDatabaseSuccess);

                                        }
                                        else
                                        {
                                            db = new Database(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                                            if (db.GetUser(match.Groups[2].Value).GetName() == match.Groups[2].Value && db.GetUser(match.Groups[2].Value).GetPassword()== match.Groups[3].Value)
                                            {
                                                writer.WriteLine(MiniSQLEngine.Messages.OpenDatabaseSuccess);
                                            }
                                            else
                                            {
                                                writer.WriteLine(MiniSQLEngine.Messages.SecurityIncorrectLogin);
                                                db = null;
                                            }                                      
                                        }
                                        f = true;
                                    }
                                    else
                                    {
                                        j++;
                                    }
                                }
                                if(f == false)
                                {
                                    if (match.Groups[2].Value.Equals("admin") && match.Groups[3].Value.Equals("admin"))
                                    {
                                        db = new Database(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                                        writer.WriteLine(MiniSQLEngine.Messages.CreateDatabaseSuccess);

                                    }
                                    else
                                    {
                                        writer.WriteLine(MiniSQLEngine.Messages.SecurityIncorrectLogin);
                                    }
                                }
                                
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
                Console.WriteLine("The file doesn´t exist ");
                //The program stops for 5 seconds
                Thread.Sleep(5000);

            }
        }
    }
}
