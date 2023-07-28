using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Models;
using ProductSellStore.Data;

namespace ProductSellStore.Services
{
    public class CategoryServes : ICategoryServes
    {
        private readonly ProductSellStoreDbContext _db;

        public CategoryServes(ProductSellStoreDbContext db)
        {
            _db = db;
        }
        public async Task AddCategory(string categoyName)
        {
            Category category= new Category();
            category.Name = categoyName;
           await _db.Categories.AddAsync(category);
           await _db.SaveChangesAsync();
        }

        public async Task<List<Category>>AllCategory()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task RemoveCategory(string categoyName)
        {
          var Category= await _db.Categories.FirstOrDefaultAsync(x=>x.Name==categoyName);
          if (Category != null)
          {
                _db.Categories.Remove(Category);
                await _db.SaveChangesAsync();
            }
          
        }
    }
}
