using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Interface;

namespace ProductSellStore.Controllers
{
    public class Products : Controller
    {
        private readonly IProductSellStore _iProductSellStore;
        public Products(IProductSellStore productSellStore)
        {
            _iProductSellStore = productSellStore;
        }
        public async Task<IActionResult> All()
        {

            var Model = await _iProductSellStore.AllItems();
            return View(Model);
        }

    }
}
