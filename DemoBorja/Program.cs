using System;
using System.Collections.Generic;
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
            Database db = new Database("prueba");
            string res0 = db.Query("CREATE TABLE tabla1 (nombre TEXT);");
            Console.WriteLine("Resultado del create table: " + res0);
            string res1 = db.Query("INSERT INTO tabla1 (nombre) VALUES (nombre1);");
            Console.WriteLine("Resultado del insert: " + res1);
            string res2 = db.Query("UPDATE tabla1 SET nombre=Andoni WHERE nombre=nombre1;");           
            Console.WriteLine("Resultado del update: " + res2);
            string res3 = db.Query("SELECT nombre FROM tabla1 WHERE nombre=Andoni;");
            Console.WriteLine("Resultado del Select: " + res3);
            string res4 = db.Query("DELETE FROM tabla1 WHERE nombre=Andoni;");
            Console.WriteLine("Resultado del Delete: " + res4);
        }
    }
}
