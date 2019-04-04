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
        private List<Table> tables;
        private List<User> users;
        private List<Security_profile> profiles;
        private User currentUser;
        public Database(string pName)
        {
            string path = @"..\..\..\DB\" + pName;

            if (!System.IO.Directory.Exists(path))
            {
                name = pName;
                tables = new List<Table>();
                users = new List<User>();
                profiles = new List<Security_profile>();
                users.Add(new User("admin", "admin", null));
                currentUser = new User(null, null, null);
            }
            else
            {
                tables = new List<Table>();
                users = new List<User>();
                users.Add(new User("admin", "admin", null));
                profiles = new List<Security_profile>();
                OpenDatabase(pName);
            }
        }
        public List<Security_profile> GetSecurity_Profiles()
        {
            return profiles;
        }

        public Security_profile GetSecurityProfile(string pName)
        {
            for (int i = 0; i <= profiles.Count; i++)
            {
                if (profiles.ElementAt(i).GetName().Equals(pName))
                {
                    return profiles.ElementAt(i);
                }
            }
            return null;
        }

        public Boolean SecurityProfileExists(string pName)
        {
            for (int i = 0; i < profiles.Count; i++)
            {
                if (profiles.ElementAt(i).GetName().Equals(pName))
                {
                    return true;
                }
            }
            return false;
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
        public string DeleteUser(string pName)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (users[i].GetName().Equals(pName))
                {
                    users.RemoveAt(i);
                    return Messages.SecurityUserDeleted;
                }
            }
            return Messages.SecurityUserDoesNotExist;
        }
        public void DropSecurityProfile(string pSecProf)
        {
            Security_profile defoult = new Security_profile("default");
            for (int i = 0; i < users.Count; i++)
            {
                if ( users.ElementAt(i).GetName()!=Constants.adminName && users.ElementAt(i).GetSecurity_Profile().GetName() == pSecProf)
                {
                    users.ElementAt(i).SetSecurityProfile(defoult);
                }
            }
            int j = 0;
            Boolean eliminated = false;
            while(j<profiles.Count && !eliminated)
            {
                if(profiles[j].GetName()== pSecProf)
                {
                    profiles.RemoveAt(j);
                    eliminated = true;
                }
                else
                {
                    j++;
                }
            }
        }        
        public string AddUser(string name, string pass, string profile)
        {
            Boolean encontrado = false;
            int i = 0;
            while(!encontrado && i < profiles.Count)
            {
                if(profiles[i].GetName()== profile)
                {
                    encontrado = true;
                }
                else
                {
                    i++;
                }
            }
            if (i != profiles.Count)
            {
                User user = new User(name, pass, profiles[i]);
                users.Add(user);
                return Messages.SecurityUserCreated;
             }
            else
            {
                return Messages.SecurityProfileDoesNotExist;
            }
        }

        public void setCurrentUser(User pUser)
        {
            currentUser = pUser;
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
                    if (HasPrivilege(match.Groups[1].Value, "DELETE"))
                    {
                       return new Delete(match.Groups[1].Value, match.Groups[2].Value);
                    }
                    else
                    {
                    return new PrivilegeError();
                    }
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
                    if (HasPrivilege(match.Groups[1].Value, "INSERT"))
                    {
                        return new Insert(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                    }
                    else
                    {
                        return new PrivilegeError();
                    }

                }
                match = Regex.Match(query, RegularExpressions.Select);
                if (match.Success)
                {
                    if (HasPrivilege(match.Groups[2].Value, "SELECT"))
                    {
                        return new Select(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                    }
                    else
                    {
                       return new PrivilegeError();
                    }
                }
                match = Regex.Match(query, RegularExpressions.Update);
                if (match.Success)
                {
                    if (HasPrivilege(match.Groups[1].Value, "UPDATE"))
                    {
                    return new Update(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                    }
                    else
                    {
                        return new PrivilegeError();
                    }
                }
                match = Regex.Match(query, RegularExpressions.CreateSecurity);
                if (match.Success)
                {
                if (isAdmin())
                {
                    return new CreateSecurity(match.Groups[1].Value);
                }
                else
                {
                    return new PrivilegeError();
                }
                    
                }
                match = Regex.Match(query, RegularExpressions.DropSecurity);
                if (match.Success)
                {
                if (isAdmin())
                {
                    return new DropSecurity(match.Groups[1].Value);
                }
                else
                {
                    return new PrivilegeError();
                }
                
                }
                match = Regex.Match(query, RegularExpressions.Grant);
                if (match.Success)
                {
                if (isAdmin())
                {
                    return new Grant(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                }
                else
                {
                    return new PrivilegeError();
                }
               
                }
                match = Regex.Match(query, RegularExpressions.Revoke);
                if (match.Success)
                {
                if (isAdmin())
                {
                    return new Revoke(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                }
                else
                {
                    return new PrivilegeError();
                }
                
                }
                match = Regex.Match(query, RegularExpressions.AddUser);
                if (match.Success)
                {
                if (isAdmin())
                {
                    return new AddUser(match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value);
                }
                else
                {
                    return new PrivilegeError();
                }
                
                }
                match = Regex.Match(query, RegularExpressions.DeleteUser);
                if (match.Success)
                {
                if (isAdmin())
                {
                    return new DeleteUser(match.Groups[1].Value);
                }
                else
                {
                    return new PrivilegeError();
                }
                
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
            string securityPath = @"..\..\..\DB\" + name + @"\Security\";
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path);
            }
            for (int i = 0; i < tables.Count; i++)
            {
                string pathTable = @"..\..\..\DB\" + name + @"\" + tables[i].GetName() + ".txt";
                using (StreamWriter writer = File.CreateText(pathTable))
                {
                    writer.WriteLine(tables[i].GetName());
                    writer.WriteLine(tables[i].GetAtributes());
                    for (int j = 0; j < tables[i].GetDatas().Count; j++)
                    {
                        int k;
                        for (k = 0; k < tables[i].GetDatas().ElementAt(j).Length - 1; k++)
                        {
                            writer.Write(tables[i].GetDatas().ElementAt(j).ElementAt(k) + ",");
                        }
                        writer.Write(tables[i].GetDatas().ElementAt(j).ElementAt(k) + ";" + "\r\n");
                    }
                    if (!System.IO.Directory.Exists(securityPath))
                    {
                        System.IO.Directory.CreateDirectory(securityPath);
                    }
                    for (int j = 0; j < profiles.Count; j++)
                    {
                        string pathProfile = @"..\..\..\DB\" + name + @"\Security\" + profiles[j].GetName() + ".txt";
                        using (StreamWriter writer1 = File.CreateText(pathProfile))
                        {
                            writer1.WriteLine(profiles[j].GetName());
                            for (int k = 0; k < profiles[j].GetPrivilege().Count; k++)
                            {
                                writer1.WriteLine(profiles[j].GetPrivilege().ElementAt(k) + "," + profiles[j].GetTable().ElementAt(k));
                            }
                        }
                    }
                    string pathUser = @"..\..\..\DB\" + name + @"\Security\Users.txt";
                    using (StreamWriter writer1 = File.CreateText(pathUser))
                    {
                        writer1.WriteLine("users");
                        for (int k = 0; k < users.Count; k++)
                        {
                            if (users[k].GetName() != Constants.adminName)
                            {
                                writer1.WriteLine(users[k].GetName() + "," + users[k].GetPassword() + "," + users[k].GetSecurity_Profile().GetName());
                            }                        
                        }
                    }
                }
            }
        }
        private void OpenDatabase(string pName)
        {
            string path = @"..\..\..\DB\" + pName;
            string securityPath = @"..\..\..\DB\" + pName + @"\Security\";
            name = pName;
            string[] files = System.IO.Directory.GetFiles(path);
            for (int i = 0; i < files.Length; i++)
            {
                string[] lines = System.IO.File.ReadAllLines(files[i]);
                tables.Add(new Table(lines[0], lines[1]));
                for(int j = 2;j<lines.Length;j++ )
                {
                    tables[i].Insert(lines[j], "");
                }
            }
            string[] files1 = System.IO.Directory.GetFiles(securityPath);
            int pos = 0;
            for (int i = 0; i < files1.Length; i++)
            {     
                string[] lines = System.IO.File.ReadAllLines(files1[i]);
                if(lines[0] != "users")
                {
                    profiles.Add(new Security_profile(lines[0]));
                    for (int j = 1; j < lines.Length; j++)
                    {
                        string[] at = lines[j].Split(',');
                        for(int l=0; l < profiles.Count; l++)
                        {
                            if (profiles[l].GetName() == lines[0])
                            {
                                profiles[l].Grant(at[0], at[1]);
                            }
                        }
                       
                    }
                }
                else
                {
                    pos = i;
                }               
            }
            string [] lines1 = System.IO.File.ReadAllLines(files1[pos]);
            for (int p = 1; p < lines1.Length; p++)
            {
                string[] at = lines1[p].Split(',');
                AddUser(at[0],at[1],at[2]);
            }

        }
        public User GetUser(string pUser)
        {
            for(int i = 0; i < users.Count; i++)
            {
                if (users.ElementAt(i).GetName().Equals(pUser))
                {
                    return users.ElementAt(i);
                }              
            }
            return null;
        }
        private Boolean HasPrivilege(string pTable, string pQuery)
        {
            if (currentUser.GetName() != Constants.adminName)
            {
                Boolean encontrado = false;
                int i = 0;
                while (!encontrado && i < currentUser.GetSecurity_Profile().GetTable().Count)
                {
                    if (currentUser.GetSecurity_Profile().GetTable().ElementAt(i) == pTable && currentUser.GetSecurity_Profile().GetPrivilege().ElementAt(i) == pQuery)
                    {
                        encontrado = true;
                    }
                    else
                    {
                        i++;
                    }
                }
                return encontrado;
            }
            else { return true; }
        }
        private Boolean isAdmin()
        {
            if(currentUser.GetName().Equals(Constants.adminName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

       
    }
   
}
