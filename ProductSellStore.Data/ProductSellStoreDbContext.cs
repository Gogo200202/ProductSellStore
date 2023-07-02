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

        public List<Category> SeededCategories()
        {
            List<Category> categories = new List<Category>();

            Category ElectricalAppliances = new Category();
            ElectricalAppliances.Id = 1;
            ElectricalAppliances.Name = "Electrical appliances";

            Category OfficeSupplies = new Category();
            OfficeSupplies.Id= 2;
            OfficeSupplies.Name = "Office supplies";

            Category KitchenSupply = new Category();
            KitchenSupply.Id = 3;
            KitchenSupply.Name = "Kitchen supply";

            categories.Add(ElectricalAppliances);
            categories.Add(OfficeSupplies);
            categories.Add(KitchenSupply);

            return categories;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var SeedCategores = SeededCategories();
            builder.Entity<Category>().HasData(SeedCategores);
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