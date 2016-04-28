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
        private User user;
        private Profile profile;
        
        public UsersFactory(SignUpModel model){
            this.model = model;
        }
        
        public void Create(){
            CreateUser();
            CreateProfile();
        }
        
        public User GetUser(){
            return user;
        }
        
        public Profile GetProfile(){
            return profile;
        }
        
        internal void CreateUser(){
            user = new User();
            user.SetEmail(model.email);
            user.SetPassword(model.senha);
        }
        
        internal void CreateProfile(){
            profile = new Profile();
            profile.SetName(model.nome);
            
            if(model.telefones!=null){
                foreach (var telphoneModel in model.telefones)
                {
                    var tel = new Telphone();
                    tel.SetPrefix(int.Parse(telphoneModel.ddd));
                    tel.SetNumber(telphoneModel.numero);
                    profile.AddTelphone(tel);
                }
            }
        }
    }
}