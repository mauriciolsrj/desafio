
            
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
    public class RegisterUserService : AccountsService, IRegisterUserService
    {
        public RegisterUserService(IProfileRepository profileRepository, 
                                   IUsersRepository usersRepository) : base (profileRepository, usersRepository)
        {
        }
        
        public RegisteredUserModel Register(SignUpModel model){
            factory = new UsersFactory(model);
            factory.Create();
            user = factory.GetUser();
            profile = factory.GetProfile();
            profile.SetUserId(user.Id);
                
            ValidateDuplicatedUser();
            GenerateUserToken();    
                
            profileRepository.Insert(profile);
            usersRepository.Insert(user);
                
            return GetRegisteredUserModel();
        }
        
        private void ValidateDuplicatedUser(){
            var lUser = usersRepository.GetByEmail(user.Email);
            
            if(lUser!=null)
                throw new DuplicatedUserException("E-mail já existente");
        }
    }
}