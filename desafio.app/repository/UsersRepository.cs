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
        
        public override IQueryable<User> GetAll() { 
               return context.Users.Take(10);
        }

        public override void Insert(User entity) {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        
         public User GetByEmail(string email){
            // TODO: rever o IEnumerable no Core 1.0
            return context.Users.ToList().FirstOrDefault();
        }
        
        public override void Delete(User entity) { 
            
        }
    }
}