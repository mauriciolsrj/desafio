using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;

namespace desafio.app.repository
{
    public class UsersRepository : RepositoryBase<User>
    {
        public UsersRepository(UsersContext context) : base(context) {
            
        }
        
        public override User GetById(int id) {
            return null;
        }

        public override IQueryable<User> GetAll(Expression<Func<User, bool>> filter) { 
               return context.Users.Take(10);
        }
        
         public override IQueryable<User> GetAll() { 
               return context.Users.Take(10);
        }

        public override void Insert(User entity) {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        
        public override void Delete(int id) { 
            
        }
        
        public override void Delete(User entity) { 
            
        }
    }
}