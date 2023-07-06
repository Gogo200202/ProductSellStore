using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using ProductSellStore.Interface;
using ProductSellStore.ViewModel;

namespace ProductSellStore.Controllers
{
    public class Products : Controller
    {
        private readonly IProductSellStoreServices _iProductSellStore;
        public Products(IProductSellStoreServices productSellStore)
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

            AddItemViewModel additemModel = await _iProductSellStore.GetItemToAdd();
            return  View(additemModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel ItemToBeAdded)
        {

          await  _iProductSellStore.AddItem(ItemToBeAdded);
            
          return RedirectToAction("All");
        }


        public async Task<IActionResult> Details(int id)
        {
            
            var detailsItem= await _iProductSellStore.GetItemDetails(id);

            return View(detailsItem);
        }

    }
}
