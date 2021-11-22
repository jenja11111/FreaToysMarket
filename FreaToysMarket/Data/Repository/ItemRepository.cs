using FreaToysMarket.Data.Interfaces;
using FreaToysMarket.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreaToysMarket.Data.Repository
{
    public class ItemRepository : IAllItems
    {
        private readonly AppDBContent appDBContent;

        public ItemRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        public IEnumerable<Item> Items => appDBContent.Item.Include(c => c.Category);

        public IEnumerable<Item> getFavItem => appDBContent.Item.Where(p => p.isFavourite).Include(c => c.Category);

        public Item getObjectItem(int itemId) => appDBContent.Item.FirstOrDefault(p => p.id == itemId);
        
    }
}
