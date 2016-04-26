using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.model
{
    public class SignUpModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        
        public IEnumerable<TelphoneModel> telefones { get; set;}
    }
}