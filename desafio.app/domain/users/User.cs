using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace desafio.app.domain
{
    public class User : EntityBase<Guid>
    {
        public User()
        {
            Created = DateTime.Now;
        }
        
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        
        public DateTime LastLogon{ get; protected set; }
        public DateTime Created { get; protected set; }
        
        public void setEmail(string email){
            // TODO: assertion
            Email = email;       
        }
        
        public void setPassword(string password){
            // TODO: assertion
            Password = password;       
        }
        
         public void setLastLogon(DateTime lastLogon){
            // TODO: assertion
            LastLogon = lastLogon;       
        }
    }
}