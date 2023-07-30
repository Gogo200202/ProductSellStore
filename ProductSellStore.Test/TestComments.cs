using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductSellStore.Data;
using ProductSellStore.Data.Models;
using ProductSellStore.Interface;
using ProductSellStore.Services;

namespace ProductSellStore.Test
{
    public class TestComments
    {
        private ProductSellStoreDbContext dbContext;
        private ICommentServes Coments;
        [SetUp]
        public void TestInitialize()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new ApplicationUser
            {
                Id = "bd82398d-3960-46a9-b659-42bdcec8495f",
                Email = "user@gmail.com",
                NormalizedEmail = "USER@gmail.com",
                UserName = "user",
                NormalizedUserName = "USer",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D"),
                PasswordHash = hasher.HashPassword(null, "123456@")
            };

           
            Item item1 = new Item();
            item1.Id = 2;
            item1.Name = "Aser Thinkpad";
            item1.Description = "good pc";

            item1.PhotoUrl = "https://pcbuild.bg/assets/products/000/000/247/000000247696--laptop-lenovo-thinkpad-14-g1-20u2s7cy00.jpg";
            item1.CategoreId = 1;
         


            var options = new DbContextOptionsBuilder<ProductSellStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductDb") // Give a Unique name to the DB
                .Options;
            this.dbContext = new ProductSellStoreDbContext(options);
            
            this.dbContext.ApplicationUser.AddAsync(user);
            this.dbContext.Items.AddAsync(item1);
            this.dbContext.SaveChanges();
        }
        [Test]
        public async Task Test_Category_Add_ALL()
        {
            ICommentServes Coments = new CommentServes(this.dbContext);

            Coments.UserMakesComment("user", "bd82398d-3960-46a9-b659-42bdcec8495f", 2, "neshto");

            var countcatrgory = await Coments.AllCommentForThisItem(2);
            var count = countcatrgory.Count;

            Assert.AreEqual(count ,1);
        }

    }
}
