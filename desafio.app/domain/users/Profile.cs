using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.domain
{
    public class Profile
    {
        public Profile()
        {
        }
    
        public int UserId { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Telphone> Telphones { get; protected set; }
        
        public void setUserId(string name){
            // TODO: assertion
            Name = name;       
        }
        public void setName(string name){
            // TODO: assertion
            Name = name;       
        }
        
        public void addTelphone(Telphone tel){
            Telphones.Add(tel);
        }
    }
}