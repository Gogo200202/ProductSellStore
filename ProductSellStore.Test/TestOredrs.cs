using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductSellStore.Data.Models;
using ProductSellStore.Data;
using ProductSellStore.Interface;
using ProductSellStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using ProductSellStore.ViewModel.OrderViewModels;

namespace ProductSellStore.Test
{
    internal class TestOredrs
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
                .UseInMemoryDatabase(databaseName: "ProductDbOrderServes") // Give a Unique name to the DB
                .Options;
            this.dbContext = new ProductSellStoreDbContext(options);

            this.dbContext.ApplicationUser.AddAsync(user);
            this.dbContext.Items.AddAsync(item1);
            this.dbContext.Items.AddAsync(item2);
            this.dbContext.SaveChanges();
        }



        [Test]
        
        public void  Test_Order_Add_ALL()
        {
            IOrderServes orderServes = new OrderServes(dbContext);

            orderServes.addItemToShopingCar("bcd657ac-87da-443d-b86e-68a2aa84a932", 2);
            int count = 0;
    
            Task.Run(async () =>
                {

                    var resolt =await orderServes.MyOrders("bcd657ac-87da-443d-b86e-68a2aa84a932");
                    count=resolt.Count();

                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(count, 1);
        }

        [Test]
        public void Test_Order_Remove()
        {
            IOrderServes orderServes = new OrderServes(dbContext);

            
            int count = 0;

            Task.Run(async () =>
                {
                   await orderServes.addItemToShopingCar("bcd657ac-87da-443d-b86e-68a2aa84a932", 3);

                    await orderServes.RemoverUserItem("bcd657ac-87da-443d-b86e-68a2aa84a932", 3);

                    var resolt = await orderServes.MyOrders("bcd657ac-87da-443d-b86e-68a2aa84a932");
                    count = resolt.Count();

                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(count, 1);
        }

        [Test]
        public void Test_Order_UpdateAmount()
        {
            IOrderServes orderServes = new OrderServes(dbContext);


            int count = 0;
            ItemUser itemUser = new ItemUser();

            Task.Run(async () =>
                {
                    await orderServes.addItemToShopingCar("bcd657ac-87da-443d-b86e-68a2aa84a932", 2);

                    await orderServes.updateAmount("bcd657ac-87da-443d-b86e-68a2aa84a932",2,5);
                  var  orders=await orderServes.MyOrders("bcd657ac-87da-443d-b86e-68a2aa84a932");

                    itemUser = orders[0];
                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(itemUser.Amount, 5);

        }

        [Test]
        public void Test_Order_User_Makes_Order_All_Orders()
        {
            IOrderServes orderServes = new OrderServes(dbContext);

            

            MakeOrder order = new MakeOrder();
            order.FirstName = "Ivaн";
            order.LastName = "Draganov";
            order.Email ="Neshto";
            order.Address = "Neshto";
            order.Country = "Neshto";
            order.Amount = 1;
            order.PhoneNumber = "0890584830";
            order.State = "Neshto";
            order.Zip = "6000";
            order.Description = "Neshto";
           
            int count = 0;
        

            Task.Run(async () =>
                {

                    await orderServes.UserMakesOrder("bcd657ac-87da-443d-b86e-68a2aa84a932", order);
                   var listofOrders= await orderServes.AllOreders("",0);
                   count = listofOrders.allOrders.Count;
                })
                .GetAwaiter()
                .GetResult();

            Assert.AreEqual(count, 1);

        }

    }
}
