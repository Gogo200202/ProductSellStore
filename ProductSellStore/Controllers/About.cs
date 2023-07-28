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
        public IActionResult TermsOfService()
        {
            return View();
        }
        public IActionResult ShippingPolicy()
        {
            return View();
        }
        public IActionResult RefundPolicy()
        {
            return View();
        }
    }
}
