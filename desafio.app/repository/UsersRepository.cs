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

        public override void Insert(User entity) {
            context.Users.Add(entity);
            context.SaveChanges();
        }
        
        public User GetByEmail(string email){
            return context.Users.FirstOrDefault(u=> u.Email == email);
        }
        
        public bool VerifyUserExistsByEmail(string email){
            return context.Users.FirstOrDefault(u=> u.Email == email) != null;
        }
    }
}