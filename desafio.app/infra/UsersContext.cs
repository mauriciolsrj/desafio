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
        public UsersContext()
        {
            
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Telphone> Telphones { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase();
        }
        /*
        public override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Telphone>()
                .HasOne(p => p.Profile)
                .WithMany(b => b.Telphones);
            
            base.OnModelCreating(modelBuilder);
        }*/
    }
}