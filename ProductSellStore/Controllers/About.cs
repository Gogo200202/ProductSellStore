using Microsoft.AspNetCore.Mvc;

namespace ProductSellStore.Controllers
{
    public class About : Controller
    {
        public IActionResult Us()
        {
            return View();
        }

        public IActionResult Policy()
        {
            return View();
        }
    }
}
