using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.model
{
    public class RegisteredUserModel
    {
        public Guid id { get; set; }
        public string token { get; set; }
        
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        
        public IEnumerable<TelphoneModel> telefones { get; set;}
        
        public DateTime data_criacao { get; set; }
        public DateTime data_atualizacao { get; set; }
        public DateTime ultimo_login { get; set; }
    }
}