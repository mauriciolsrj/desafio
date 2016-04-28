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
    public class GetUserService : AccountsService, IGetUserService
    {
        public GetUserService(IProfileRepository profileRepository, 
                              IUsersRepository usersRepository) : base (profileRepository, usersRepository)
        {
        }
        
        public RegisteredUserModel Get(string token){   
            Assertion.IsFalse(string.IsNullOrEmpty(token), "Informe um token válido");
            Authorize(token);
            profile = profileRepository.GetByUserId(user.Id);
                        
            return GetRegisteredUserModel();
        }
    }
}