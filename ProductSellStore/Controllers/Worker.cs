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
        private readonly ICategoryServes _categoryServices;
          
        public Worker(IOrderServes IOrderServes, IUserServices userServices, ICategoryServes categoryServices)
        {
            this._IOrderServes = IOrderServes;
            _userServices = userServices;
            _categoryServices = categoryServices;
        }
        [Authorize(Roles = "Admin,Worker")]
        public async Task<IActionResult> AllOrders(string SearchString, int numberPage)
        {
            if (numberPage < 0)
            {
                return BadRequest();
            }

            var resolt = await _IOrderServes.AllOreders(SearchString, numberPage);
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

        public async Task<IActionResult> Categorys()
        {
            
            return View(await _categoryServices.AllCategory());
        }

        public async Task<IActionResult> AddCategorys(string CategoryToAdd)
        {
            
           
           await _categoryServices.AddCategory(CategoryToAdd);
            return RedirectToAction("Categorys");
        }

        public async Task<IActionResult> RemoveCategorys(string CategoryToRemove)
        {


            await _categoryServices.RemoveCategory(CategoryToRemove);
            return RedirectToAction("Categorys");
        }
    }
}
