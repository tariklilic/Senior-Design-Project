using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using computershopAPI.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace computershopAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Product> Products { get; set; }

    }
}