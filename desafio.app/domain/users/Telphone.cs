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
    }
}