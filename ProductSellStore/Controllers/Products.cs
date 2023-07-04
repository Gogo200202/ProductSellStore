using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using ProductSellStore.Interface;
using ProductSellStore.ViewModel;

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
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddItemViewModel additemModel = _iProductSellStore.GetItemToAdd();
            return View(additemModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel ItemToBeAdded)
        {

          await  _iProductSellStore.AddItem(ItemToBeAdded);
            
          return RedirectToAction("All");
        }

    }
}
