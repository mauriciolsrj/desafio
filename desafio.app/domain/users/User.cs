using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.app;

namespace desafio.app.domain
{
    public class User : EntityBase<Guid>
    {
        public User()
        {
            Created = DateTime.Now;
            LastLogon = DateTime.Now;
            Id = Guid.NewGuid();
        }
        
        public string Email { get; protected set; }
        public string Password { get; protected set; }
        
        public DateTime LastLogon{ get; protected set; }
        public DateTime Created { get; protected set; }
        
        public void SetEmail(string email){
            if(string.IsNullOrEmpty(email))
                throw new ArgumentException("Informe o e-mail do usuário.");
            
            Email = email;
        }
        
        public void SetPassword(string password){
           if(string.IsNullOrEmpty(password))
                throw new ArgumentException("Informe a senha do usuário.");
            
            Password = password;       
        }
        
         public void SetLastLogon(DateTime lastLogon){
             if(lastLogon==DateTime.MinValue)
                throw new ArgumentException("Data de último acesso inválida.");
            
            LastLogon = lastLogon;       
        }
        
        public bool PasswordMatch(string password){
            return password == Password;
        }
    }
}