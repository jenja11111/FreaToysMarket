using FreaToysMarket.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Interfaces
{
    public interface IAllItems
    {
        IEnumerable<Item> Items { get; }
        IEnumerable<Item> getFavItem { get; }
        Item getObjectItem(int itemId);
    }
}
