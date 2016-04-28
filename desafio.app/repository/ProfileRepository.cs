using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Linq.Expressions;
using System.Threading.Tasks;
using desafio.app.context;
using desafio.app.domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.repository
{
    public class ProfileRepository : RepositoryBase<Profile>, IProfileRepository
    {
        public ProfileRepository():base() {
            
        }
        
        public override void Insert(Profile entity) {
            context.Profiles.Add(entity);
            context.SaveChanges();
        }
        
        public override void Update(Profile entity){
            context.Profiles.Attach(entity);
            context.SaveChanges(); 
        } 
        
        public Profile GetByUserId(Guid userId){
            return context.Profiles.Include(t=> t.Telphones).FirstOrDefault(p=> p.UserId == userId);
        }  
    }
}