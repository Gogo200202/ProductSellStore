using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Models;
using System.Diagnostics;
using ProductSellStore.Interface;

namespace ProductSellStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductSellStoreServices _iProductSellStore;

        public HomeController(ILogger<HomeController> logger, IProductSellStoreServices productSellStore)
        {
            _logger = logger;
            _iProductSellStore= productSellStore;
        }

        public async Task<IActionResult> Index()
        {
            var Model = await _iProductSellStore.AllItems("", 0);
            return View(Model);
        }

       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}