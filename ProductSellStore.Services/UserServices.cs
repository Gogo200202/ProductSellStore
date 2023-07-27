using ProductSellStore.Data;
using ProductSellStore.Data.Models;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ProductSellStore.Services
{
    public class UserServices : IUserServices
    {
        private readonly ProductSellStoreDbContext _context;
        public UserServices(ProductSellStoreDbContext context)
        {
            _context = context;
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
            ApplicationUser user = await _context.ApplicationUser.FirstOrDefaultAsync(x=>x.Id==id);
            return user;
        }
    }
}
