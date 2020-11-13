using Kerberos.DataAccess.Mapping;
using Kerberos.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kerberos.DataAccess.Context
{
    public class DatabaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../Kerberos.DataAccess/Kerberos.db;Cache=Shared");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration<AppUser>(new AppUserMap());
            modelBuilder.ApplyConfiguration<AppRole>(new AppRoleMap());
            modelBuilder.ApplyConfiguration<AppUserRole>(new AppUserRoleMap());
            modelBuilder.ApplyConfiguration<Product>(new ProductMap());
        }
        public DbSet<AppRole> tAppRole { get; set; }
        public DbSet<AppUser> tAppUser { get; set; }
        public DbSet<AppUserRole> tAppUserRoles { get; set; }
        public DbSet<Product> tProduct { get; set; }
    }
}
