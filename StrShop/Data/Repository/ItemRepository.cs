using Microsoft.EntityFrameworkCore;
using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Repository
{
    public class ItemRepository : IAllItems
    {

        private readonly DBconnection dBconnection;

        public  ItemRepository(DBconnection dBconnection) { this.dBconnection = dBconnection; }

        public IEnumerable<Item> Items => dBconnection.Item.Include(c=>c.Category).Include(p=>p.Producer);

        public IEnumerable<Item> GetAction => dBconnection.Item.Where(p => p.isAction).Include(c =>c.Category);

        public Item GetItemById(int ItemId) => dBconnection.Item.FirstOrDefault(p => p.id == ItemId);
        
    }
}
