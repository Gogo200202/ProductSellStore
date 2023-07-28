using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.ViewModel.ItemsViewModels
{
    public class AllItems
    {
        public int id { get; set; }

        public string Name { get; set; }
        public int Raiting { get; set; }
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }


    }
}
