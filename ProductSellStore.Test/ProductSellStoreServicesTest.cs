using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductSellStore.Data.Models;
using ProductSellStore.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductSellStore.Interface;
using ProductSellStore.ViewModel.ItemsViewModels;
using NUnit.Framework.Interfaces;
using ProductSellStore.Services;

namespace ProductSellStore.Test
{
    public class ProductSellStoreServicesTest
    {
        private ProductSellStoreDbContext dbContext;
       

        [OneTimeSetUp]
        public void TestInitialize()
        {
            var hasher = new PasswordHasher<IdentityUser>();
            var user = new ApplicationUser
            {
                Id = "bcd657ac-87da-443d-b86e-68a2aa84a932",
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

            Item item2 = new Item();
            item2.Id = 3;
            item2.Name = "Aser Thinkpad";
            item2.Description = "good pc";

            item2.PhotoUrl = "https://pcbuild.bg/assets/products/000/000/247/000000247696--laptop-lenovo-thinkpad-14-g1-20u2s7cy00.jpg";
            item2.CategoreId = 1;




            var options = new DbContextOptionsBuilder<ProductSellStoreDbContext>()
                .UseInMemoryDatabase(databaseName: "ProductDbProductServes")
                .Options;

            this.dbContext = new ProductSellStoreDbContext(options);

            if (!dbContext.ApplicationUser.Any(x => x.Id == "bcd657ac-87da-443d-b86e-68a2aa84a932"))
            {
                this.dbContext.ApplicationUser.AddAsync(user);

                this.dbContext.Items.AddAsync(item1);
                this.dbContext.Items.AddAsync(item2);
            }

            this.dbContext.SaveChanges();
        }

        [Test]
        public void ProductSellStoreServices_Add()
        {

         IProductSellStoreServices services = new ProductSellStoreServices(dbContext);
        AddItemViewModel item= new AddItemViewModel();
        
            item.Name = "Aser Thinkpad";
            item.Description = "good pc";

           item.PhotoUrl = "https://pcbuild.bg/assets/products/000/000/247/000000247696--laptop-lenovo-thinkpad-14-g1-20u2s7cy00.jpg";
            item.Category = 1;
            int count = 0;
            Task.Run(async () =>
                {

                   await services.AddItem(item);
                   count = dbContext.Items.ToList().Count;

                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(count, 3);

        }

        [Test]
        public void ProductSellStoreServices_ALl()
        {
            IProductSellStoreServices services = new ProductSellStoreServices(dbContext);
            
            int count = 0;
            Task.Run(async () =>
                {

                    
                    var page =await services.AllItems("",0);
                    count = page.allItems.Count;

                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(count, 3);
        }

        [Test]
        public void ProductSellStoreServices_Remove()
        {
            IProductSellStoreServices services = new ProductSellStoreServices(dbContext);

            int count = 0;
            Task.Run(async () =>
                {


                     await services.Delete(3);
                    count =  dbContext.Items.ToList().Count;

                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(count, 2);
        }
       
    }
}
