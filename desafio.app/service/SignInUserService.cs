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
    public class SignInService : AccountsService, ISignInUserService
    {
        private const string invalidUserAndPasswordError = "Usuário e/ou senha inválidos";
        
        public SignInService() {
        }
        
        public RegisteredUserModel SignIn(SignInModel model){
            try
            {   
                Initialize();
                user = usersRepository.GetByEmail(model.email);
                
                if(user==null)
                    throw new ArgumentException(invalidUserAndPasswordError);
                
                if(user.PasswordMatch(model.senha)){
                    profile = profileRepository.GetByUserId(user.Id);
                    
                    return GetRegisteredUserModel();
                }else
                    throw new ArgumentException(invalidUserAndPasswordError);
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                Dispose();
            }
        }
    }
}