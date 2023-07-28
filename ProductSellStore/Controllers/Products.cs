using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using ProductSellStore.Interface;
using ProductSellStore.ViewModel.ItemsViewModels;
using System.Data;
using System.Security.Claims;

namespace ProductSellStore.Controllers
{
    public class Products : Controller
    {
        private readonly IProductSellStoreServices _iProductSellStore;
        private readonly ICommentServes _iCommentServes;
        public Products(IProductSellStoreServices productSellStore, ICommentServes iCommentServes)
        {
            _iProductSellStore = productSellStore;
            _iCommentServes = iCommentServes;
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
            var coments = await _iCommentServes.AllCommentForThisItem(id);
            detailsItem.AllComents= coments;

            return View(detailsItem) ;
        }

        public async Task<IActionResult> Delete(int id)
        {

            await _iProductSellStore.Delete(id);

            return RedirectToAction("All");
        }


        public async Task<IActionResult> MakeComment(string comment, int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            
             await _iCommentServes.UserMakesComment(userName,userId, id, comment);
            return RedirectToAction("All");
        }
    }
}

