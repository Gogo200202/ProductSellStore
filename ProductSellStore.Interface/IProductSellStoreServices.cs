﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Interface
{

    
    public interface IProductSellStoreServices
    {
        public  Task<List<AllItems>> AllItems();
        public  Task AddItem(AddItemViewModel item);

        public Task<AddItemViewModel> GetItemToAdd();

   
        public Task<DetailsViweModel> GetItemDetails(int id);
    }
}