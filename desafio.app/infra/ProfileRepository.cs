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
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository(UsersContext context) : base(context) {
            
        }
        
        public override void Insert(Profile entity) {
            context.Profiles.Add(entity);
            context.SaveChanges();
        }
        
        public Profile GetByUserId(Guid userId){
            return context.Profiles.FirstOrDefault(p=> p.UserId == userId);
        }   
    }
}