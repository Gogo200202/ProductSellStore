using Models;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductSellStore.Data;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Services
{
    public class ProductSellStore : IProductSellStore
    {
        private readonly ProductSellStoreDbContext _context;
        public ProductSellStore(ProductSellStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddItem(AddItemViewModel item)
        {
            Item itemForDb = new Item();
            itemForDb.Name = item.Name;
            itemForDb.Description = item.Description;
            itemForDb.Price = item.Price;
            itemForDb.Rating = item.Rating;
            itemForDb.PhotoUrl = item.PhotoUrl;
            itemForDb.CategoreId= item.CategoreId;


           await _context.Items.AddAsync(itemForDb);

            await _context.SaveChangesAsync();

        }

       
        public async Task<List<AllItems>> AllItems()
        {
            var allItems = await _context.Items.Select(x => new AllItems()
            {
                id = x.Id,
                Name = x.Name,
                Raiting = x.Rating,
                PhotoUrl = x.PhotoUrl,
                Price = x.Price,

            }).ToListAsync();

            return allItems;
        }

        public AddItemViewModel GetItemToAdd()
        {
            AddItemViewModel itemToAdd = new AddItemViewModel();
            var categoreas = _context.Categories.ToList();
            itemToAdd.Categorys = categoreas;
            return itemToAdd;


        }
    }
}
