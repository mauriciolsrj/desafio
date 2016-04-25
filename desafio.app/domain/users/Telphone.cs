using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.domain
{
    public class Telphone : EntityBase<int>
    {
        public Telphone()
        {
        }
        
        public int Prefix { get; protected set; } 
        public string Number { get; protected set; } 
        
         public void setPrefix(int prefix){
            // TODO: assertion
            Prefix = prefix;       
        }
        
         public void setNumber(string number){
            // TODO: assertion
            Number = number;       
        }
    }
}