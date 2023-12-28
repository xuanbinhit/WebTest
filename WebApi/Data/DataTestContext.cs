using WebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApi.Data
{
    public class DataTestContext : DbContext
    {
        public DataTestContext(DbContextOptions<DataTestContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerBuy> CustomerBuys { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<ShopProduct> ShopProducts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<CustomerBuy>().ToTable("CustomerBuy");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<Shop>().ToTable("Shop");
            modelBuilder.Entity<ShopProduct>().ToTable("ShopProduct");
        }
    }
}
