using Microsoft.AspNetCore.Mvc;

namespace ProductSellStore.Controllers
{
    public class Checkout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
