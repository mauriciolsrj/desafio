
            
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using desafio.app.repository;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.service
{
    public class RegisterUserService
    {
        private UsersRepository repository; 
        
        public RegisterUserService() {
            
             var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
            optionsBuilder.UseInMemoryDatabase();
            
            var context = new UsersContext(optionsBuilder.Options);
            repository = new UsersRepository(context);
        }
        
        public List<User> Insert(User user){
            repository.Insert(user);
            return repository.GetAll().ToList();
        }
    }
}