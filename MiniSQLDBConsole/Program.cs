using MiniSQLEngine;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MiniSQLDBConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Write the sentences: ");
            string input = Console.ReadLine();
            Stopwatch stopWatch = new Stopwatch();
            Database db = new Database("database");

            while (!input.Equals("end"))
            {
                stopWatch.Start();
                string res = db.Query(input);
                stopWatch.Stop();
                Console.WriteLine(res + " (" + Convert.ToDecimal(stopWatch.Elapsed.TotalSeconds) + "s)");
                Console.WriteLine("Write the sentences: ");
                input = Console.ReadLine();

            }

        }
    }
}
