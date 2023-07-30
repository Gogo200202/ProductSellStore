using ProductSellStore.ViewModel.ItemsViewModels;
using ProductSellStore.ViewModel.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.ViewModel.PagesViewModels
{
    public class PageInfoOrders
    {
        public PageInfoOrders()
        {
            allOrders = new List<AllOrederesViweModel>();
        }
        public int TotalPages { get; set; }
        public string WordsToSearch { get; set; }
        public int curentPageNumber { get; set; }
        public bool HasNextPage { get; set; }

        public List<AllOrederesViweModel> allOrders { get; set; }
    }
}
