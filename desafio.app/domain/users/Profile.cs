using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.domain
{
    public class Profile : EntityBase<int>
    {
        public Profile()
        {
            Telphones = new List<Telphone>();
        }
    
        public Guid UserId { get; protected set; }
        public string Name { get; protected set; }
        public ICollection<Telphone> Telphones { get; protected set; }
        
        public void SetUserId(Guid userId){
            if(userId==Guid.Empty) throw new ArgumentException("Informe o userId do perfil.");
            
            UserId = userId;  
        }
        public void SetName(string name){
            if(string.IsNullOrEmpty(name)) throw new ArgumentException("Informe o nome do perfil.");
            
            Name = name;       
        }
        
        public void AddTelphone(Telphone tel){
            if(tel==null) throw new ArgumentException("Informe um telefone válido.");
                
            Telphones.Add(tel);
        }
    }
}