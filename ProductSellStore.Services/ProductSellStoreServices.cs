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
using ProductSellStore.ViewModel.ItemsViewModels;
using ProductSellStore.ViewModel.PagesViewModels;

namespace ProductSellStore.Services
{
    public class ProductSellStoreServices : IProductSellStoreServices
    {
        private readonly ProductSellStoreDbContext _context;
        public ProductSellStoreServices(ProductSellStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddItem(AddItemViewModel item)
        {
            Item itemForDb = new Item();
            itemForDb.Name = item.Name;
            itemForDb.Description = item.Description;
            itemForDb.Price = item.Price;
           
            itemForDb.PhotoUrl = item.PhotoUrl;
            itemForDb.CategoreId= item.Category;


           await _context.Items.AddAsync(itemForDb);

            await _context.SaveChangesAsync();

        }

       
        public async Task<PageInfo> AllItems(string SearchString,int numberPage)
        {

            int pageSize = 3;
            PageInfo pageInfo = new PageInfo();
            
            

            pageInfo.curentPageNumber = numberPage;

            pageInfo.WordsToSearch = SearchString;

            var allItems = _context.Items.AsQueryable();

            pageInfo.TotalPages = (int)Math.Ceiling(allItems.Count() / (double)pageSize);

            if (!string.IsNullOrWhiteSpace(SearchString))
            {
                allItems= allItems.Where(b => b.Name.Contains(SearchString));
            }

            allItems = allItems.Skip((numberPage) * pageSize).Take(pageSize);

            var resolt= await allItems.Select(x => new AllItems()
                {
                    id = x.Id,
                    Name = x.Name,
                  
                    PhotoUrl = x.PhotoUrl,
                    Price = x.Price,

                }).ToListAsync();

            
            pageInfo.allItems= resolt;
            pageInfo.HasNextPage= pageInfo.curentPageNumber < pageInfo.TotalPages-1;
            return pageInfo;
        }

        public async Task Delete(int id)
        {
            var itemToDelete =await _context.Items.FirstOrDefaultAsync(x=>x.Id==id);

            _context.Items.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<DetailsViweModel> GetItemDetails(int id)
        {
            var resoltDetails =  await _context.Items.Include(x=>x.Category).FirstOrDefaultAsync(x=>x.Id==id);

            DetailsViweModel details = new DetailsViweModel();

            details.Id = resoltDetails.Id;
            details.Name= resoltDetails.Name;
            details.Description= resoltDetails.Description;
            
            details.Price = resoltDetails.Price;
            details.PhotoUrl = resoltDetails.PhotoUrl;
            details.CategoreId= resoltDetails.CategoreId;
            details.Category= resoltDetails.Category;



            return details;
        }

        public async Task<AddItemViewModel> GetItemToAdd()
        {
            AddItemViewModel itemToAdd = new AddItemViewModel();
            var categoreas =await _context.Categories.ToListAsync();
            itemToAdd.Categorys = categoreas;
            return itemToAdd;


        }
    }
}
