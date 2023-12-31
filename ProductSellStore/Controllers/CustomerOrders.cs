﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProductSellStore.Interface;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace ProductSellStore.Controllers
{
    [Authorize]
    public class CustomerOrders : Controller
    {
        private readonly IOrderServes _iOrderServes;
       

        public CustomerOrders(IOrderServes iOrderServes)
        {
            _iOrderServes=iOrderServes;
         
        }

        public async Task<IActionResult> AddOrder(int Id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (!await _iOrderServes.validItem(Id))
            {
                return BadRequest();
            }
            await _iOrderServes.addItemToShopingCar(userId, Id);
         

            var parameters = new RouteValueDictionary();

            parameters["id"] = Id;

            TempData["ShowPopUp"] = "fade show";

            return RedirectToAction("Details","Products", parameters);
        }
        public async Task<IActionResult> UpdataAmount(int itemId,int amount)
        {
            if (!await _iOrderServes.validItem(itemId))
            {
                return BadRequest();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _iOrderServes.updateAmount(userId, itemId, amount);

            return RedirectToAction("UserCuretnItems");
        }

        public async Task<IActionResult> UserCuretnItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

             var resolt= await _iOrderServes.MyOrders(userId);
             
            return View(resolt);
        }

        public async Task<IActionResult> RemoverCuretnUserItem(int id)
        {
            if (!await _iOrderServes.validItem(id))
            {
                return BadRequest();
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

             await _iOrderServes.RemoverUserItem(userId, id);

            return RedirectToAction("UserCuretnItems");
        }

        
    }
}
