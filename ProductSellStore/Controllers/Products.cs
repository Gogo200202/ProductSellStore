using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Configuration;
using ProductSellStore.Interface;
using ProductSellStore.Services;
using ProductSellStore.ViewModel.ItemsViewModels;
using System.Data;
using System.Security.Claims;

namespace ProductSellStore.Controllers
{
    
    public class Products : Controller
    {
        private readonly IProductSellStoreServices _iProductSellStore;
        private readonly ICommentServes _iCommentServes;
        private readonly IOrderServes _iOrderServes;
        public Products(IProductSellStoreServices productSellStore, ICommentServes iCommentServes, IOrderServes iOrderServes)
        {
            _iProductSellStore = productSellStore;
            _iCommentServes = iCommentServes;
            _iOrderServes = iOrderServes;
        }
        [AllowAnonymous]
        public async Task<IActionResult> All(string SearchString,int numberPage)
        {
            if (numberPage < 0)
            {
                return BadRequest();
            }

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

        [AllowAnonymous]

        public async Task<IActionResult> Details(int id)
        {
            if (!await _iOrderServes.validItem(id))
            {
                return BadRequest();
            }
            var detailsItem= await _iProductSellStore.GetItemDetails(id);
            var coments = await _iCommentServes.AllCommentForThisItem(id);
            detailsItem.AllComents= coments;

            return View(detailsItem) ;
        }
        [Authorize(Roles = "Admin,Worker")]
        public async Task<IActionResult> Delete(int id)
        {

            await _iProductSellStore.Delete(id);

            return RedirectToAction("All");
        }

        [Authorize]
        public async Task<IActionResult> MakeComment(string comment, int id)
        {
            if (string.IsNullOrWhiteSpace(comment))
            {
                return RedirectToAction("Details", new { id }); ;
            }

            if (!await _iOrderServes.validItem(id))
            {
                return BadRequest();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userName = User.FindFirstValue(ClaimTypes.Name);
            
             await _iCommentServes.UserMakesComment(userName,userId, id, comment);

             return RedirectToAction("Details", new { id }); ;
        }
        [Authorize]
        public async Task<IActionResult> DeleteComment(int itemId,int Comentid)
        {

            await _iCommentServes.DeleteComment(Comentid);


            return RedirectToAction("Details", new { id = itemId }); ;
        }
    }
}

