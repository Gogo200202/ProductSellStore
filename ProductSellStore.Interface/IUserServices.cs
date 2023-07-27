using ProductSellStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Interface
{
    public interface IUserServices
    {
        public Task<ApplicationUser> GetUserById(string id);
        public Task<UserViweModel> GetByuserName(string UserName);
        public Task MakeUserWorker(string UserId);
    }
}
