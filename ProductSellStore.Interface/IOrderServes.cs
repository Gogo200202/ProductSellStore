using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProductSellStore.ViewModel.OrderViewModels;
using ProductSellStore.ViewModel.PagesViewModels;

namespace ProductSellStore.Interface
{
    public interface IOrderServes
    {
        public Task  addItemToShopingCar(string userId,int idItem);
        public Task<List<ItemUser>> MyOrders(string userId);
        public Task RemoverUserItem(string userId,int idItem);

        public Task<PageInfoOrders> AllOreders (string SearchString, int numberPage);

        public Task UserMakesOrder(string userId, MakeOrder makeOrder);

        public Task updateAmount(string userId,int ItemId, int Amount);

        public Task<bool> validItem(int ItemId);


    }
}
