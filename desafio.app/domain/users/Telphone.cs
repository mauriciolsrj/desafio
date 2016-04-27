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
        
        public void SetPrefix(int prefix){
             Assertion.IsFalse(prefix==0, "Informe o prefixo do telefone.");
            
            Prefix = prefix;       
        }
        
         public void SetNumber(string number){
            Assertion.IsFalse(string.IsNullOrEmpty(number), "Informe o número do telefone.");
            
            Number = number;       
        }
    }
}