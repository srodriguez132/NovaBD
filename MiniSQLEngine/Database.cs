using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace MiniSQLEngine
{
    public class Database
    {
        private string name;
        List<Table> tables = new List<Table>();

        public Database(string pName)
        {
            name = pName;

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
                if (tables[i].getName().Equals(name))
                {
                    tables[i].delete(null);

                }
            }

        }
        public Table GetTable(string pName)
        {

            for (int i = 0; i < tables.Count; i++)
            {
                if (tables[i].getName().Equals(name))
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
                if(match.Length>2)
                {
                    return new Select(match.Groups[3].Value, match.Groups[4].Value, match.Groups[5].Value);
                    
                }
                else
                {
                    return new Select(match.Groups[1].Value, match.Groups[2].Value, null);
                }
            }
            match = Regex.Match(query, RegularExpressions.Update);
            if (match.Success)
            {
                return new Update(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
            }
            return null;
        }
        public string Query(string phrase)
        {
           MiniSQLEngine.MiniSQL q = Parse(phrase);
           return q.Execute(this);            
        }
    }
}
