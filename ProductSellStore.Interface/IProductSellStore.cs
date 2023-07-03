using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Interface
{

    
    public interface IProductSellStore
    {
        public  Task<List<AllItems>> AllItems();
    }
}
