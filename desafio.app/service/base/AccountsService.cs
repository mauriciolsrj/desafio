
            
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using desafio.app.model;
using desafio.app.repository;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.service
{
    public class AccountsService : ServiceBase
    {
        public AccountsService() {
        }
        
        protected User user;
        protected Profile profile;
        internal UsersFactory factory;
        
        protected IUsersRepository usersRepository;
        protected IProfileRepository profileRepository;

        protected void CreateUsersRepository(){
           if(usersRepository==null)
                usersRepository = new UsersRepository(context);
        }
        
        protected void CreateProfileRepository(){
            if(profileRepository==null)
                profileRepository = new ProfileRepository(context);
        }
        
        protected RegisteredUserModel GetRegisteredUserModel(){
            return new RegisteredUserModel(){
                nome = profile.Name,
                email = user.Email,
                senha = user.Password,
                telefones = GetTelphoneModelCollection(),
                data_criacao = user.Created,
                data_atualizacao = user.Created,
                ultimo_login = user.LastLogon,
                id = user.Id,
                token = Guid.NewGuid() // TODO: gerar token automaticamnete
            };
        }
        
        protected IEnumerable<TelphoneModel> GetTelphoneModelCollection(){
            if(profile==null || profile.Telphones == null)
                return new List<TelphoneModel>();
            
            var telphones = new List<TelphoneModel>();
            
            foreach(var tel in profile.Telphones){
               var telphoneModel = new TelphoneModel(){
                  ddd = tel.Prefix,
                  numero = tel.Number  
                };
                
               telphones.Add(telphoneModel);
            }
            
            return telphones;
        }
        
        protected User GetUser(){
            return factory.GetUser();
        }
        
        protected Profile GetProfile(){
            return factory.GetProfile();
        }
        
        protected void Dispose(){
            if(usersRepository != null)
                usersRepository.Dispose();
                
            if(profileRepository != null)
                profileRepository.Dispose();
                
            DisposeContext();
        }
        
        protected override void InitializeRepositories(){
            CreateUsersRepository();
            CreateProfileRepository();
        }
    }
}