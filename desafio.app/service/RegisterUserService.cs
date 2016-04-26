
            
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
    public class RegisterUserService : ServiceBase, IDisposable
    {
        private UsersRepository usersRepository;
        private ProfileRepository profileRepository;
        
        public RegisterUserService() {
            usersRepository = new UsersRepository(context);
            profileRepository = new ProfileRepository(context);
        }
        
        public Profile GetByUserId(){
            return profileRepository.GetByUserId(Guid.NewGuid());
        }
        
        public RegisteredUserModel Register(SignUpModel model){
            var factory = new UsersFactory(model);
            var user = factory.CreateUser();
            var profile = factory.CreateProfile();
            
            if(usersRepository.GetByEmail(user.Email)!=null){
                throw new ArgumentException("E-mail já existente");
            }
            
            usersRepository.Insert(user);
            profile.SetUserId(user.Id);
            profileRepository.Insert(profile);
            
            var registeredUserModel = new RegisteredUserModel(){
                nome = profile.Name,
                email = user.Email,
                senha = user.Password,
                telefones = model.telefones,
                data_criacao = user.Created,
                data_atualizacao = user.Created,
                ultimo_login = user.LastLogon,
                id = user.Id,
                token = Guid.NewGuid()
            };
            
            return registeredUserModel;
        }
        
        public void Dispose(){
            usersRepository.Dispose();
            profileRepository.Dispose();
            ContextDispose();
        }
    }
}