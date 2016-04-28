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
    public class UsersRepository : RepositoryBase<User>, IUsersRepository
    {
        public UsersRepository():base() {
            
        }

        public override void Insert(User entity) {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        
        public override void Update(User entity){
            context.Users.Attach(entity);
            context.SaveChanges(); 
        } 
        
        public User GetByEmail(string email){
            return context.Users.FirstOrDefault(u=> u.Email == email);
        }
        
        public User GetByToken(string token){
            return context.Users.FirstOrDefault(u=> u.Token == token);
        }
        
        public User GetById(Guid id){
            return context.Users.FirstOrDefault(u=> u.Id == id);
        }
    }
}