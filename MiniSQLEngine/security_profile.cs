using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniSQLEngine
{
    class Security_profile
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
                    if (indexes.ElementAt(i) == table.IndexOf(pTable))
                    {
                    privilege_type.RemoveAt(indexes.ElementAt(i));
                    table.RemoveAt(indexes.ElementAt(i));
                    }                
                }                  
        }
    }
}
