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
        private static Database db;
        private static User user;
        static void Main(string[] args)
        {
            
            Console.WriteLine("Write the name of the database: ");
            string input = Console.ReadLine();
            db = new Database(input);
            Console.WriteLine("Write the name of the user: ");
            string inputUser = Console.ReadLine();
            user = db.GetUser(inputUser);
            string inputPass= null;
            while (inputPass == null && user.GetPassword() != inputPass)
            {
                Console.WriteLine("Write the password of the user: ");
                inputPass = Console.ReadLine();
            }
            Console.WriteLine("Correct password");
            db.setCurrentUser(user);
            try
            {
                Console.WriteLine("Write the sentences: ");
                input = Console.ReadLine();
                Stopwatch stopWatch = new Stopwatch();
            
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
            finally
            {
                db.Dispose();
            }

        }
       
    }
}
