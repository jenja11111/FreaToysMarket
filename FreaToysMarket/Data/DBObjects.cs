using FreaToysMarket.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {                
            if (!content.Category.Any())
                content.Category.AddRange(Categories.Select(c => c.Value));

            if (!content.Item.Any())
            {
                content.AddRange(
                    new Item
                    {
                        name = "Динозаврик",
                        shortDesc = "Небольшой, красивый динозаврик",
                        longDesc = "Всегда смотрит нежным взглядом на вас",
                        img = "/img/dino.jpg",
                        price = 15,
                        isFavourite = true,
                        available = true,
                        Category = Categories["Игрушки"]
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
                        Category = Categories["Игрушки"]
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
                        Category = Categories["Закладки"]
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
                        Category = Categories["Закладки"]
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
                        Category = Categories["Игрушки"]
                    }
                );
            }

            content.SaveChanges();

        }

        private static Dictionary<string, Category> category;

        static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                        new Category { categoryName = "Игрушки"},
                        new Category { categoryName = "Закладки"}
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category ct in list)
                        category.Add(ct.categoryName, ct);
                }

                return category;
            }
        }
    }
}
