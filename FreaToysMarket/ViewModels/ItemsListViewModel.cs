using FreaToysMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.ViewModels
{
    public class ItemsListViewModel
    {
        public IEnumerable<Item> allItems { get; set; }

        public string currCategory { get; set; }
    }
}
