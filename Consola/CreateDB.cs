using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MiniSQLEngine;

namespace Consola
{
    class CreateDB
    {
        static void Main(string[] args)
        {
            Database db = new Database("prueba");
            db.CreateTable("tabla1", "nombre");
            string res = db.Query("INSERT INTO tabla1 (nombre) VALUES (nombre1);");
            string res2 = db.Query("UPDATE tabla1 SET nombre=Andoni WHERE nombre=nombre1;");
            Console.WriteLine("Resultado del Insert: " + res);
            Console.WriteLine("Resultado del Update: " + res2);


        }
    }
}
