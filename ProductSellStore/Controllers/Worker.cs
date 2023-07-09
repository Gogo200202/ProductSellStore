using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Interface;

namespace ProductSellStore.Controllers
{
    public class Worker : Controller
    {
        private readonly IOrderServes _IOrderServes;
        public Worker(IOrderServes IOrderServes)
        {
            this._IOrderServes=IOrderServes;
        }
        public async Task<IActionResult> AllOrders()
        {
            var resolt = await _IOrderServes.AllOreders();
            return View(resolt);
        }
    }
}
