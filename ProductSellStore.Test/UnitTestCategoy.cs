using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProductSellStore.Data;
using ProductSellStore.Data.Models;
using ProductSellStore.Interface;
using ProductSellStore.Services;

namespace ProductSellStore.Test
{
    public class Tests
    {

        private ProductSellStoreDbContext dbContext;
        private ICategoryServes Category;
        [OneTimeSetUp]
        public void TestInitialize()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new ApplicationUser
            {

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
            

            var options = new DbContextOptionsBuilder<ProductSellStoreDbContext>()
                    .UseInMemoryDatabase(databaseName: "ProductDbCommentServes") // Give a Unique name to the DB
                    .Options;
            this.dbContext = new ProductSellStoreDbContext(options);
            this.dbContext.ApplicationUser.AddAsync(user);
            this.dbContext.SaveChanges();
        }
        //Test Category
        [Test]
        public void Test_Category_Add()
        {
            ICategoryServes categoryToAdd = new CategoryServes(this.dbContext);

            categoryToAdd.AddCategory("neshto");

            var countcatrgory= dbContext.Categories.Count();

            Assert.AreEqual(countcatrgory,1);
        }
        [Test]
        public void Test_Category_Add_None()
        {
            ICategoryServes categoryToAdd = new CategoryServes(this.dbContext);

            

            var countcatrgory = dbContext.Categories.Count();
            Assert.AreEqual( countcatrgory ,1);
        }
        [Test]
        public void Test_Category_Remove()
        {
            ICategoryServes categoryToAdd = new CategoryServes(this.dbContext);

            
            categoryToAdd.RemoveCategory("neshto");

            var countcatrgory = dbContext.Categories.Count();
            Assert.AreEqual(countcatrgory,0);
        }
        [Test]
        public void Test_Category_Remove_None()
        {
            ICategoryServes categoryToAdd = new CategoryServes(this.dbContext);

            categoryToAdd.RemoveCategory("");

            var countcatrgory = dbContext.Categories.Count();
            Assert.AreEqual( countcatrgory , 0);
        }
    }
}