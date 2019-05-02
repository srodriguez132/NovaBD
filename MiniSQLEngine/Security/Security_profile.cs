using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
   public class Security_profile
    {
        private string name;
        private List<string> privilege_type;
        private List<string> table;
        public Security_profile(string pName)
        {
            name = pName;
            privilege_type = new List<string>();
            table = new List<string>();
        }
        public void Grant (string pPrivilege,string pTable)
        {
            privilege_type.Add(pPrivilege);
            table.Add(pTable);
        }
        public void Revoke (string pPrivilege,string pTable)
        {                      
            List<int> indexes = new List<int>();          
                for(int k = 0; k < privilege_type.Count; k++)
                {
                    if(privilege_type.ElementAt(k)== pPrivilege)
                    {
                        indexes.Add(k);
                    }
                }        
                for (int i = 0; i < indexes.Count; i++)
                {
                    if (table.ElementAt(indexes.ElementAt(i)) == pTable)
                    {
                    privilege_type.RemoveAt(indexes.ElementAt(i));
                    table.RemoveAt(indexes.ElementAt(i));
                    }                
                }                  
        }
        public string GetName()
        {
            return name;
        }
        public List<string> GetTable()
        {
            return table;
        }
        public List<string> GetPrivilege()
        {
            return privilege_type;
        }     
    }
}
