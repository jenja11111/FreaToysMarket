using FreaToysMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Item> favItems { get; set; }
    }
}
