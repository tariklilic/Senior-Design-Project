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

            modelBuilder.Entity<CartItem>()
                .HasKey(x=> x.Id);

            modelBuilder.Entity<CartItem>()
                .HasOne(x =>x.User)
            .WithMany(x => x.cartItems)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<CartItem>()
                .HasOne(x => x.Product)
                .WithMany(x => x.cartItems)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<PurchaseHistory>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(x => x.User)
            .WithMany(x => x.purchaseHistories)
                .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<PurchaseHistory>()
                .HasOne(x => x.Product)
                .WithMany(x => x.purchaseHistories)
                .HasForeignKey(x => x.ProductId);


        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Component> Components { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<PurchaseHistory> PurchaseHistory { get; set; }
    }
}