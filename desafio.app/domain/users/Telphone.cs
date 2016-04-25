using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics.Contracts;

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
             if(prefix==0)
                throw new ArgumentException("Informe o prefixo do telefone.");
            
            Prefix = prefix;       
        }
        
         public void SetNumber(string number){
            if(string.IsNullOrEmpty(number))
                throw new ArgumentException("Informe o número do telefone.");
            
            Number = number;       
        }
    }
}