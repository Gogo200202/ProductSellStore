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
        [OneTimeSetUp]
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
                .UseInMemoryDatabase(databaseName: "ProductDbCategory") // Give a Unique name to the DB
                .Options;
            this.dbContext = new ProductSellStoreDbContext(options);
            if (!dbContext.ApplicationUser.Any(x => x.Id == "bcd657ac-87da-443d-b86e-68a2aa84a932"))
            {
                this.dbContext.ApplicationUser.AddAsync(user);

                this.dbContext.Items.AddAsync(item1);
         
            }

            this.dbContext.SaveChanges();
        }
        [Test]
        public void Test_Category_Add_ALL()
        {
            ICommentServes Coments = new CommentServes(this.dbContext);
            int count=0;
           Task.Run(async () =>
                {

                  await  Coments.UserMakesComment("user", "bd82398d-3960-46a9-b659-42bdcec8495f", 2, "neshto");

                    
                    count = dbContext.Items.ToList().Count;

                })
                .GetAwaiter()
                .GetResult();
            
            

            Assert.AreEqual(count ,1);
        }

        [Test]
        public async Task Test_Category_ALL()
        {
            ICommentServes Coments = new CommentServes(this.dbContext);

            int countDB = 0;
            int countServes = 0;
            Task.Run(async () =>
                {


                    var serves =await Coments.AllCommentForThisItem(2);
                    countServes = serves.Count;
                    countDB = dbContext.ItemComments.ToList().Count;

                })
                .GetAwaiter()
                .GetResult();


            Assert.AreEqual(countDB, countServes);
        }

    }
}
