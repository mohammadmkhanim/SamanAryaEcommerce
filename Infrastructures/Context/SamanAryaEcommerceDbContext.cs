using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructures.Context
{
    public class SamanAryaEcommerceDbContext : DbContext
    {
        public SamanAryaEcommerceDbContext(DbContextOptions<SamanAryaEcommerceDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasMany(r => r.Users)
                .WithMany(u => u.Roles)
                .UsingEntity<UserRole>();
        }
    }
}