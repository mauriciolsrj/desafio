using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using desafio.app;
using desafio.app.model;
using desafio.app.domain;
using desafio.app.service;
using desafio.app.repository;
using desafio.app.context;

namespace desafio.tests
{
    public class TestBase
    {
        private IUsersRepository usersRepository;
        private IProfileRepository profileRepository;
        private RegisterUserService registerUserService;
        private SignInService signInService;
        private GetUserService getUserService;
        
        public TestBase(){
            //context = new UsersContext();
        }
        
        public IProfileRepository GetProfileRepository(){
            if(profileRepository==null)
                profileRepository = new ProfileRepository();
            
            return profileRepository;
        }
        
        public IUsersRepository GetUsersRepository(){
            if(usersRepository==null)
                usersRepository = new UsersRepository();
            
            return usersRepository;
        }
        
        public RegisterUserService GetRegisterUserService(){
            if(registerUserService==null)
                registerUserService = new RegisterUserService(GetProfileRepository(), GetUsersRepository());
            
            return registerUserService;
        }
        
        public SignInService GetSignInService(){
            if(signInService==null)
                signInService = new SignInService(GetProfileRepository(), GetUsersRepository());
            
            return signInService;
        }
        
        public GetUserService GetGetUserService(){
            if(getUserService==null)
                getUserService = new GetUserService(GetProfileRepository(), GetUsersRepository());
            
            return getUserService;
        }
    }
}