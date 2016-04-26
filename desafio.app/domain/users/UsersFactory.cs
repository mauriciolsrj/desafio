using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.app.model;

namespace desafio.app.domain
{
    public class UsersFactory
    {
        private SignUpModel model;
        
        public UsersFactory(SignUpModel model){
            this.model = model;
        } 
        
        public User CreateUser(){
            var user = new User();
            user.SetEmail(model.email);
            user.SetPassword(model.senha);
            return user;
        }
        
        public Profile CreateProfile(){
            var profile = new Profile();
            profile.SetName(model.nome);
            
            foreach (var telphoneModel in model.telefones)
            {
                var tel = new Telphone();
                tel.SetPrefix(telphoneModel.ddd);
                tel.SetNumber(telphoneModel.numero);
                
                profile.AddTelphone(tel);
            }
            
            return profile;
        }
    }
}