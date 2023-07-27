using ProductSellStore.Data;
using ProductSellStore.Data.Models;
using ProductSellStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Services
{
    public class UserServices : IUserServices
    {
        private readonly ProductSellStoreDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserServices(ProductSellStoreDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<ApplicationUser> GetUserById(string id)
        {
            ApplicationUser user = await _context.ApplicationUser.FirstOrDefaultAsync(x=>x.Id==id);
            return user;
        }
        public async Task<UserViweModel> GetByuserName(string UserName)
        {
            var users = await _context.ApplicationUser.Select(x => new UserViweModel()
            {
                Id = x.Id,
                UserName = x.UserName,
                UserEmail = x.Email,
            }).FirstOrDefaultAsync(x=>x.UserName== UserName);

            return users;
        }

        public async Task MakeUserWorker(string UserId)
        {

            ApplicationUser adminUser = await _userManager.FindByIdAsync(UserId);

            await _userManager.AddToRoleAsync(adminUser, "Worker");
                 

            
        }
    }
}
