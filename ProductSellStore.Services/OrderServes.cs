using Models;
using ProductSellStore.Data;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductSellStore.ViewModel;
using System.Net;
using System.Diagnostics.Metrics;

namespace ProductSellStore.Services
{
    public class OrderServes : IOrderServes
    {
        private readonly ProductSellStoreDbContext _context;
        public OrderServes(ProductSellStoreDbContext context)
        {
            _context = context;
        }

        public async Task addItemToShopingCar(string userId, int idItem)
        {
            ItemUser userItem = new ItemUser();
            userItem.UserId = userId;
            userItem.ItemId = idItem;

      

            await _context.ItemsUsers.AddAsync(userItem);
            await _context.SaveChangesAsync();
            
           
        }

        public async Task<List<AllOrederesViweModel>> AllOreders()
        {

            var resoltOfAllOreders = await _context.Orders.Select(x => new AllOrederesViweModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                Country = x.Country,
                State = x.State,
                Zip = x.Zip,
                Description = x.Description,
                Item = x.Item,
                User = x.User,
                Id =x.Id,
                ItemId = x.ItemId,
             
                UserId = x.UserId,
             
                CreatedOn = x.OrderOn,
                AllStatus = x.OrderStatus

            }).ToListAsync();

            return resoltOfAllOreders;
        }

        public async Task<List<ItemUser>> MyOrders(string userId)
        {
            var resoltMyOrders =await _context.ItemsUsers
                .Include(x=>x.Item)
                .Include(x=>x.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            return resoltMyOrders;

        }

        public async Task RemoverUserItem(string userId, int idItem)
        {
            var resoltDelete =
                await _context.ItemsUsers.FirstOrDefaultAsync(x => x.User.Id == userId && x.Item.Id == idItem);

            _context.ItemsUsers.Remove(resoltDelete);
            await _context.SaveChangesAsync();
        }

        public async Task UserMakesOrder(string userId, MakeOrder makeOrder)
        {
            var resoltAllCirentUserOreders= await _context.ItemsUsers
                .Include(x => x.Item)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .Select(x=>new Orders()
                {
                    FirstName= makeOrder.FirstName,
                    LastName= makeOrder.LastName,
                    Email= makeOrder.Email,
                    Address= makeOrder.Address,
                    Country= makeOrder.Country,
                    PhoneNumber = makeOrder.PhoneNumber,
                    State= makeOrder.State,
                    Zip= makeOrder.Zip,
                    Description= makeOrder.Description,
                    ItemId =x.ItemId,
                    UserId =x.UserId,
                    Item = x.Item,
                    User = x.User
                })
                .ToListAsync();

            var resoltAllUserOreders = await _context.ItemsUsers
                .Include(x => x.Item)
                .Include(x => x.User)
                .Where(x => x.UserId == userId)
                .ToListAsync();

            _context.ItemsUsers.RemoveRange(resoltAllUserOreders);
          

           await _context.Orders.AddRangeAsync(resoltAllCirentUserOreders);
            await _context.SaveChangesAsync();

            
        }
    }
}
