using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;

namespace ProductSellStore.Data
{
   
    public class ProductSellStoreDbContext : IdentityDbContext
    {
       
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemUser> ItemsUsers { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public ProductSellStoreDbContext(DbContextOptions<ProductSellStoreDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ItemUser>(option =>
            {
                option.HasKey(keys => new
                {
                    keys.ItemId, keys.UserId
                });
            });
            base.OnModelCreating(builder);
        }
    }
}