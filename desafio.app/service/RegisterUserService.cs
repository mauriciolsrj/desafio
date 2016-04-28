
            
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
        public RegisteredUserModel Register(SignUpModel model){
            try
            {
                Initialize();
                factory = new UsersFactory(model);
                factory.Create();
                user = GetUser();
                profile = GetProfile();
                profile.SetUserId(user.Id);
                
                ValidateDuplicatedUser();
                
                usersRepository.Insert(user);
                profileRepository.Insert(profile);
                
                return GetRegisteredUserModel();
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                Dispose();
            }
        }
        
        private void ValidateDuplicatedUser(){
            if(usersRepository.VerifyUserExistsByEmail(user.Email))
                    throw new DuplicatedUserException("E-mail já existente");
        }
    }
}