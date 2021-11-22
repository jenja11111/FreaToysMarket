using FreaToysMarket.Data.Interfaces;
using FreaToysMarket.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders _allOrders, ShopCart shopCart)
        {
            this._allOrders = _allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            shopCart.listShopItems = shopCart.GetShopItems();

            if(shopCart.listShopItems.Count == 0)
            {
                ModelState.AddModelError("","У вас должны быть в корзине товары!");
            }

            if(ModelState.IsValid)
            {
                _allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {            
            return View();
        }
    }
}
