using ProductSellStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductSellStore.Interface
{
    public interface IUserServices
    {
        public Task<ApplicationUser> GetUserById(string id);
    }
}
