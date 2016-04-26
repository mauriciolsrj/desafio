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
    public class ProfileRepository : RepositoryBase<Profile>
    {
        public ProfileRepository(UsersContext context) : base(context) {
            
        }
        
        public Profile GetByUserId(Guid userId){
            return context.Profiles.FirstOrDefault();
        }
        
        public override IQueryable<Profile> GetAll() { 
            return context.Profiles.Take(10);
        }

        public override void Insert(Profile entity) {
            context.Profiles.Add(entity);
            context.SaveChanges();
        }
        
        public override void Delete(Profile entity) { 
            
        }
    }
}