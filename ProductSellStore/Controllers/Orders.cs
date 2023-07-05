using Microsoft.AspNetCore.Mvc;

namespace ProductSellStore.Controllers
{
    public class Orders : Controller
    {
        public IActionResult AddOrder()
        {
            Console.WriteLine("asdasdas");
            return RedirectToAction("All","Products");
        }
    }
}
