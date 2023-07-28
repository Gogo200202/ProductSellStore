using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProductSellStore.ViewModel;
using ProductSellStore.ViewModel.ItemsViewModels;

namespace ProductSellStore.Interface
{


    public interface IProductSellStoreServices
    {
        public Task<PageInfo> AllItems(string SerchString, int numberPage);
        public  Task AddItem(AddItemViewModel item);
        public  Task Delete(int id);

        public Task<AddItemViewModel> GetItemToAdd();

   
        public Task<DetailsViweModel> GetItemDetails(int id);
    }
}
