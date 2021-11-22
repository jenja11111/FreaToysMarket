using FreaToysMarket.Data.Interfaces;
using FreaToysMarket.Data.Models;
using FreaToysMarket.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllItems _itemRep;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllItems itemRep, ShopCart shopCart)
        {
            _itemRep = itemRep;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.GetShopItems();
            _shopCart.listShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _itemRep.Items.FirstOrDefault(i => i.id == id);
            if (item != null)
            {
                _shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
