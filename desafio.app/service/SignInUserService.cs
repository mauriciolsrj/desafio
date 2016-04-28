using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using desafio.app.model;
using desafio.app;
using desafio.app.repository;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.service
{
    public class SignInService : AccountsService, ISignInService
    {
        private const string invalidUserAndPasswordError = "Usuário e/ou senha inválidos";
        
        public RegisteredUserModel SignIn(SignInModel model){
            try
            {   
                Assertion.IsFalse(string.IsNullOrEmpty(model.email), "Informe o e-mail do usuário.");
                Assertion.IsFalse(string.IsNullOrEmpty(model.senha), "Informe a senha do usuário.");
                
                Initialize();
                
                user = usersRepository.GetByEmail(model.email);
                
                if(user==null)
                    throw new InvalidUserException(invalidUserAndPasswordError);
                
                if(user.PasswordMatch(model.senha)){
                    profile = profileRepository.GetByUserId(user.Id);
                    
                    user.SetLastLogon(DateTime.Now);
                    usersRepository.Update(user);
                    
                    return GetRegisteredUserModel();
                }
                else
                    throw new InvalidUserException(invalidUserAndPasswordError);
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