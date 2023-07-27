using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Interface;
using System.Data;
using ProductSellStore.Web.SeedRoles;

namespace ProductSellStore.Controllers
{
    public class Worker : Controller
    {
        private readonly IOrderServes _IOrderServes;
        private readonly IUserServices _userServices;
          
        public Worker(IOrderServes IOrderServes, IUserServices userServices)
        {
            this._IOrderServes = IOrderServes;
            _userServices = userServices;
        }
        [Authorize(Roles = "Admin,Worker")]
        public async Task<IActionResult> AllOrders()
        {
            var resolt = await _IOrderServes.AllOreders();
            return View(resolt);
        }

        public async Task<IActionResult> SearchUsers(string SearchString)
        {
            var user =await _userServices.GetByuserName(SearchString);
            return View(user);
        }

        public async Task<IActionResult> MakeUserWorker(string id)
        {
            await _userServices.MakeUserWorker(id);
            return RedirectToAction("SearchUsers");
        }
    }
}
