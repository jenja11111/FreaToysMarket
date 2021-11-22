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
    public class HomeController : Controller
    {
        private readonly IAllItems _itemRep;

        public HomeController(IAllItems itemRep)
        {
            _itemRep = itemRep;
        }

        public ViewResult Index()
        {
            var homeItems = new HomeViewModel() 
            {
                favItems = _itemRep.getFavItem
            };
            return View(homeItems);
        }
    }
}
