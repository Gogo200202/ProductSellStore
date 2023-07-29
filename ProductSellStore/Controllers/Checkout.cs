using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Interface;
using System.Security.Claims;
using Microsoft.VisualBasic.FileIO;
using ProductSellStore.ViewModel.OrderViewModels;

namespace ProductSellStore.Controllers
{
    public class Checkout : Controller
    {
        private readonly IOrderServes _OrderServes;
        public Checkout(IOrderServes OrderServes)
        {
            this._OrderServes=OrderServes;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var order = await _OrderServes.MyOrders(userId);

            ViewBag.Items = order.Select(x => new
            {
               curentItem= x.Item,
               curentAmount=x.Amount
            });

            MakeOrder makeOrder = new MakeOrder();
            ViewBag.Total = order.Select(x=>x.Item.Price*x.Amount).Sum();

            return View(makeOrder);
        }

        [HttpPost]
        public async Task<IActionResult> Index(MakeOrder makeOrder)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!ModelState.IsValid)
            {
                
                var order = await _OrderServes.MyOrders(userId);

                ViewBag.Items = order.Select(x => new
                {
                    curentItem = x.Item,
                    curentAmount = x.Amount
                });
                ViewBag.Total = order.Select(x => x.Item.Price * x.Amount).Sum();

                return View(makeOrder);
            }
         
           await _OrderServes.UserMakesOrder(userId, makeOrder);

            return RedirectToAction("All","Products");
        }
    }
}
