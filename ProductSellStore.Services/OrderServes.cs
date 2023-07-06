using Models;
using ProductSellStore.Data;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task<List<ItemUser>> MyOrders(string userId)
        {
            var resoltMyOrders =await _context.ItemsUsers.Include(x=>x.Item).Include(x=>x.User).Where(x => x.UserId == userId).ToListAsync();

            return resoltMyOrders;

        }

        public async Task RemoverUserItem(string userId, int idItem)
        {
            var resoltDelete =
                await _context.ItemsUsers.FirstOrDefaultAsync(x => x.User.Id == userId && x.Item.Id == idItem);

            _context.ItemsUsers.Remove(resoltDelete);
            await _context.SaveChangesAsync();
        }
    }
}
