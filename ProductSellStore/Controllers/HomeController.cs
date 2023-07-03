using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Models;
using System.Diagnostics;
using ProductSellStore.Interface;

namespace ProductSellStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductSellStore _iProductSellStore;

        public HomeController(ILogger<HomeController> logger, IProductSellStore productSellStore)
        {
            _logger = logger;
            _iProductSellStore= productSellStore;
        }

        public IActionResult Index()
        {
            
            return View();
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}