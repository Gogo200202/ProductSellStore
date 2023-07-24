using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Interface
{
    public interface IOrderServes
    {
        public Task  addItemToShopingCar(string userId,int idItem);
        public Task<List<ItemUser>> MyOrders(string userId);
        public Task RemoverUserItem(string userId,int idItem);

        public Task<List<AllOrederesViweModel>> AllOreders ();

        public Task UserMakesOrder(string userId, MakeOrder makeOrder);



    }
}
