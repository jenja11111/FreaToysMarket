using FreaToysMarket.Data.Interfaces;
using FreaToysMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Mocks
{
    public class MockItem : IAllItems
    {
        private readonly IItemsCategory _categoryItems = new MockCategory();

        public IEnumerable<Item> Items
        {
            get
            {
                return new List<Item>()
                {
                    new Item 
                    { 
                        name = "Динозаврик", 
                        shortDesc = "Небольшой, красивый динозаврик", 
                        longDesc = "Всегда смотрит нежным взглядом на вас",
                        img = "/img/dino.jpg",
                        price = 15, 
                        isFavourite = true, 
                        available = true, 
                        Category = _categoryItems.AllCategories.First()
                    },
                    new Item
                    {
                        name = "Мишка",
                        shortDesc = "Первая из работ",
                        longDesc = "Очень нравится маленьким детям",
                        img = "/img/bear.jpg",
                        price = 15,
                        isFavourite = false,
                        available = true,
                        Category = _categoryItems.AllCategories.First()
                    },
                    new Item
                    {
                        name = "Закладка полоса",
                        shortDesc = "Закладка для книги полосой",
                        longDesc = "Очень приятная на ощупь и удобная в использовании",
                        img = "/img/minion.jpg",
                        price = 12,
                        isFavourite = true,
                        available = true,
                        Category = _categoryItems.AllCategories.Last()
                    },
                    new Item
                    {
                        name = "Закладка уголок",
                        shortDesc = "Закладка для книги уголок",
                        longDesc = "Очень приятная на ощупь и удобная в использовании",
                        img = "/img/dog.jpg",
                        price = 12,
                        isFavourite = false,
                        available = false,
                        Category = _categoryItems.AllCategories.Last()
                    },
                    new Item
                    {
                        name = "Летучая мышь",
                        shortDesc = "Бижутерия",
                        longDesc = "Маленькая, удобная летучая мышка: вушается вверх ногами и спит",
                        img = "/img/mouse.jpg",
                        price = 12,
                        isFavourite = true,
                        available = true,
                        Category = _categoryItems.AllCategories.First()
                    }
                };
            }
        }
        public IEnumerable<Item> getFavItem { get; set; }

        public Item getObjectItem(int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
