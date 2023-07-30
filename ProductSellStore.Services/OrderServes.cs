using Models;
using ProductSellStore.Data;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Diagnostics.Metrics;
using ProductSellStore.ViewModel.OrderViewModels;
using ProductSellStore.ViewModel.PagesViewModels;

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

            bool validatorUserItem = await _context.ItemsUsers.AnyAsync(x => x.UserId == userId && x.ItemId == idItem);
            if (validatorUserItem)
            {
                var userItem = await _context.ItemsUsers.FirstOrDefaultAsync(x => x.ItemId == idItem);
                userItem.Amount++;
             
            }
            else
            {
                ItemUser userItem = new ItemUser();
                userItem.UserId = userId;
                userItem.ItemId = idItem;
                userItem.Amount = 1;
                await _context.ItemsUsers.AddAsync(userItem);
                


            }
            await _context.SaveChangesAsync();



        }

        public async Task<PageInfoOrders> AllOreders(string SearchString, int numberPage)
        {


            int pageSize = 3;
            PageInfoOrders pageInfo = new PageInfoOrders();



            pageInfo.curentPageNumber = numberPage;

            pageInfo.WordsToSearch = SearchString;

            var AllOrders = _context.Orders.AsQueryable();

            pageInfo.TotalPages = (int)Math.Ceiling(AllOrders.Count() / (double)pageSize);

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                AllOrders = AllOrders.Where(b => b.PhoneNumber.Contains(SearchString));
            }

            AllOrders = AllOrders.Skip((numberPage) * pageSize).Take(pageSize);



            var resoltOfAllOreders = await AllOrders.Select(x => new AllOrederesViweModel()
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                Address = x.Address,
                Country = x.Country,
                State = x.State,
                Zip = x.Zip,
                Amount = x.Amount,
                Description = x.Description,
                Item = x.Item,
                User = x.User,
                Id =x.Id,
                ItemId = x.ItemId,
             
                UserId = x.UserId,
             
                CreatedOn = x.OrderOn,
                AllStatus = x.OrderStatus

            }).ToListAsync();
            resoltOfAllOreders.Reverse();

            pageInfo.allOrders = resoltOfAllOreders;
            pageInfo.HasNextPage = pageInfo.curentPageNumber < pageInfo.TotalPages - 1;

            return pageInfo;
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

        public async Task updateAmount(string userId, int ItemId, int Amount)
        {

            var myOred = await _context.ItemsUsers
                    .FirstOrDefaultAsync(b=>b.ItemId== ItemId&&b.UserId== userId);
            myOred.Amount=Amount;
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
                    Amount = x.Amount,
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
