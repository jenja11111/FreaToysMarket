using FreaToysMarket.Data.Interfaces;
using FreaToysMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Mocks
{
    public class MockCategory : IItemsCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get 
            {
                return new List<Category>()
                {
                    new Category { categoryName = "Игрушки"},
                    new Category { categoryName = "Закладки" }
                };
            }
        }
    }
}
