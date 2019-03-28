using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;

namespace MiniSQLEngine
{
    public class Database : IDisposable
    {
        private string name;
        private Boolean disposed = false;
        List<Table> tables = new List<Table>();

        public Database(string pName)
        {
            string path = @"..\..\..\DB\" + pName;

            if (!System.IO.Directory.Exists(path))
            {
                name = pName;
            }
            else
            {
                OpenDatabase(pName);
            }
        }

        public void CreateTable(string name, string pColumns)
        {
            Table table = new Table(name, pColumns);
            tables.Add(table);
        }

        public void DeleteTable(string name)
        {
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].GetName().Equals(name))
                {
                    tables.RemoveAt(i);

                }
            }

        }
        public Table GetTable(string pName)
        {
            
            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].GetName().Equals(pName))
                {
                 
                    return tables[i];
                 
                }
               
            }
            return null;
        }
        public MiniSQLEngine.MiniSQL Parse(string query)
        {
                Match match = Regex.Match(query, RegularExpressions.BackupDatabase);
                if (match.Success)
                {
                    return new BackupDatabase(match.Groups[1].Value, match.Groups[2].Value);
                }
                match = Regex.Match(query, RegularExpressions.CreateDataBase);
                if (match.Success)
                {
                    return new CreateDataBase(match.Groups[1].Value);
                }
                match = Regex.Match(query, RegularExpressions.CreateTable);
                if (match.Success)
                {
                    return new CreateTable(match.Groups[1].Value, match.Groups[2].Value);
                }
                match = Regex.Match(query, RegularExpressions.Delete);
                if (match.Success)
                {
                    return new Delete(match.Groups[1].Value, match.Groups[2].Value);
                }
                match = Regex.Match(query, RegularExpressions.DropDataBase);
                if (match.Success)
                {
                    return new DropDataBase(match.Groups[1].Value);
                }
                match = Regex.Match(query, RegularExpressions.DropTable);
                if (match.Success)
                {
                    return new DropTable(match.Groups[1].Value);
                }
                match = Regex.Match(query, RegularExpressions.Insert);
                if (match.Success)
                {
                    return new Insert(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                }
                match = Regex.Match(query, RegularExpressions.Select);
                if (match.Success)
                {
                    return new Select(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                }
                match = Regex.Match(query, RegularExpressions.Update);
                if (match.Success)
                {
                    return new Update(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                }
                return new SyntaxError();
            
        }
        public string Query(string phrase)
        {
           MiniSQLEngine.MiniSQL q = Parse(phrase);
           return q.Execute(this);            
        }
        public string GetName()
        {
            return name;
        }

        public void Dispose()
        {
            // If this function is being called the user wants to release the
            // resources. lets call the Dispose which will do this for us.
            Dispose(true);

            // Now since we have done the cleanup already there is nothing left
            // for the Finalizer to do. So lets tell the GC not to call it later.
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            { 
            if (disposing == true)
            {
                //someone want the deterministic release of all resources
                //Let us release all the managed resources
                ReleaseManagedResources();
            }
            else
            {
                // Do nothing, no one asked a dispose, the object went out of
                // scope and finalized is called so lets next round of GC 
                // release these resources
                
            }
                // Release the unmanaged resource in any case as they will not be 
                // released by GC
                disposed = true;
                ReleaseUnmangedResources();
                
            }


        }

        private void ReleaseUnmangedResources()
        {
            Console.WriteLine("Releasing Managed Resources");
            if (this != null)
            {
                this.Dispose();
            }
        }

        private void ReleaseManagedResources()
        {
            SaveDatabase();
            Console.WriteLine("Releasing Unmanaged Resources");
        }

        private void SaveDatabase()
        {
            string path = @"..\..\..\DB\" + name;
            System.IO.Directory.CreateDirectory(path);
            for (int i = 0; i < tables.Count; i++)
            {
                string pathTable = @"..\..\..\DB\" + name+ @"\" + tables[i].GetName() + ".txt";
                using (StreamWriter writer = File.CreateText(pathTable))
                {
                    writer.WriteLine(tables[i].GetName());
                    writer.WriteLine(tables[i].GetAtributes());
                    for (int j = 0; j < tables[i].GetDatas().Count; j++)
                    {
                        int k;
                        for (k = 0; k < tables[i].GetDatas().ElementAt(j).Length-1; k++)
                        {
                            writer.Write(tables[i].GetDatas().ElementAt(j).ElementAt(k) + ",");
                        }
                            writer.Write(tables[i].GetDatas().ElementAt(j).ElementAt(k) + ";" + "\r\n");
                    }
                }
            }
        }
        private void OpenDatabase(string pName)
        {
            string path = @"..\..\..\DB\" + pName;
            System.IO.Directory.CreateDirectory(path);
            string[] files = System.IO.Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                string[] lines = System.IO.File.ReadAllLines(files[i]);
                tables.Add(new Table(lines[0], lines[1]));
                for(int j = 2;j<lines.Length;j++ )
                {
                    tables[i].Insert(lines[2], "");
                }
            }
        }
    }
   
}
