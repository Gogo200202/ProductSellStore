using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductSellStore.ViewModel.ItemsViewModels;

namespace ProductSellStore.ViewModel
{
    public class PageInfo
    {
        public PageInfo()
        {
            allItems = new List<AllItems>();
        }
        public int TotalPages { get;  set; }
        public string WordsToSearch { get; set; }
        public int curentPageNumber { get; set; }
        public bool HasNextPage { get; set; }

        public List<AllItems> allItems { get; set; }
    }
}
