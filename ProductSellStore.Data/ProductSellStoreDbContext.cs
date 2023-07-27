using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductSellStore.Data.Models;
using System.Collections.Generic;

namespace ProductSellStore.Data
{
   
    public class ProductSellStoreDbContext : IdentityDbContext<ApplicationUser>
    {
        public  DbSet<ApplicationUser> ApplicationUser { get; set; }

        public  DbSet<Worker> Workers { get; set; }
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

        public List<Item> SeededItems()
        {
            List<Item> items = new List<Item>();
            Item item1= new Item();
            item1.Id = 1;
            item1.Name = "Lenovo Thinkpad";
            item1.Description = "good pc";
            item1.Rating = 5;
            item1.PhotoUrl = "https://pcbuild.bg/assets/products/000/000/247/000000247696--laptop-lenovo-thinkpad-14-g1-20u2s7cy00.jpg";
            item1.CategoreId = 1;
            items.Add(item1);
            return items;

        }

        public ApplicationUser SeedAdmin()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new ApplicationUser
            {
             
                Email = "Admin@gmail.com",
                NormalizedEmail = "ADMIN@gmail.com",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = hasher.HashPassword(null, "123456@")
            };
            return user;
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            var SeedCategores = SeededCategories();
            builder.Entity<Category>().HasData(SeedCategores);

            var seedItems = SeededItems();
            builder.Entity<Item>().HasData(seedItems);

            var seedAdmin=SeedAdmin();
            builder.Entity<ApplicationUser>().HasData(seedAdmin);

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