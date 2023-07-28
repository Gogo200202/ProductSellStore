using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using ProductSellStore.Interface;
using ProductSellStore.ViewModel.ItemsViewModels;
using System.Data;

namespace ProductSellStore.Controllers
{
    public class Products : Controller
    {
        private readonly IProductSellStoreServices _iProductSellStore;
        public Products(IProductSellStoreServices productSellStore)
        {
            _iProductSellStore = productSellStore;
        }
        public async Task<IActionResult> All(string SearchString,int numberPage)
        {
            
            var Model = await _iProductSellStore.AllItems(SearchString, numberPage);
            
            return View(Model);

        }
        [Authorize(Roles = "Admin,Worker")]
       
        [HttpGet]
        public async Task<IActionResult> Add()
        {

            AddItemViewModel additemModel = await _iProductSellStore.GetItemToAdd();
            return  View(additemModel);
        }
        [Authorize(Roles = "Admin,Worker")]

        [HttpPost]
        public async Task<IActionResult> Add(AddItemViewModel ItemToBeAdded)
        {

          await  _iProductSellStore.AddItem(ItemToBeAdded);
            
          return RedirectToAction("All");
        }


        public async Task<IActionResult> Details(int id)
        {
            
            var detailsItem= await _iProductSellStore.GetItemDetails(id);

            return View(detailsItem) ;
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _iProductSellStore.Delete(id);

            return RedirectToAction("All");
        }

    }
}
