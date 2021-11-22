using FreaToysMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Interfaces
{
    public interface IItemsCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }
}
