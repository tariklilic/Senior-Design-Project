using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using computershopAPI.Models.Models;
using ComputerShopApi.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace computershopAPI.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seeding administrator data into DB
            SeedData.SeedAdminRole(modelBuilder);
            SeedData.SeedAdminUser(modelBuilder);
            SeedData.SeedUserRoleRelationship(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<User> Users { get; set; }
    }
}