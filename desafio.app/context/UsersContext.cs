using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using desafio.app.domain;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;

namespace desafio.app.context
{
    public class UsersContext : DbContext
    {
        public UsersContext(DbContextOptions options)
        : base(options)
        {
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Telphone> Telphones { get; set; }
        
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            
            base.OnModelCreating(modelBuilder);
        }*/
    }
}