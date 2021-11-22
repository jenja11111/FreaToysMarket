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
    public class ItemsController : Controller
    {
        private readonly IAllItems _allItems;
        private readonly IItemsCategory _allCategory;

        public ItemsController(IAllItems iAllItems, IItemsCategory iAllCategory)
        {
            _allItems = iAllItems;
            _allCategory = iAllCategory;
        }

        [Route("Items/List")]
        [Route("Items/List/{category}")]
        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Item> items = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                items = _allItems.Items.OrderBy(i => i.id);
            }
            else
            {
                if (string.Equals("toys", category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _allItems.Items.Where(i => i.Category.categoryName.Equals("Игрушки")).OrderBy(i => i.id);
                    currCategory = "Игрушки";
                }
                else if (string.Equals("bookmarks", category, StringComparison.OrdinalIgnoreCase))
                {
                    items = _allItems.Items.Where(i => i.Category.categoryName.Equals("Закладки")).OrderBy(i => i.id);
                    currCategory = "Закладки";
                }

            }
            ViewBag.Title = "Страница с товарами магазина";

            var itemObj = new ItemsListViewModel
            {
                allItems = items,
                currCategory = currCategory
            };

            return View(itemObj);
        }

        public ViewResult Index(int id)
        {
            return View(_allItems.getObjectItem(id));
        }
    }
}
