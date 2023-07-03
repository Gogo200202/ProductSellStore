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

        public async Task<List<AllItems>> AllItems()
        {
            var allItems = await _context.Items.Select(x => new AllItems()
            {
                id = x.Id,
                Name = x.Name,
                Raiting = x.Rating,
                PhotoUrl = x.PhotoUrl,

            }).ToListAsync();

            return allItems;
        }
    }
}
