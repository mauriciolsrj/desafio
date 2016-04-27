using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.app.domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.context
{
    public class MemoryContextFactory : IContextFactory
    {
        public UsersContext Create(){
            var optionsBuilder = new DbContextOptionsBuilder<UsersContext>();
            optionsBuilder.UseInMemoryDatabase();
            
            return new UsersContext(optionsBuilder.Options);
        }
    }
}