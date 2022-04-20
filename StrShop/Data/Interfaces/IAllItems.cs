using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Interfaces
{
     public interface IAllItems
    {
        IEnumerable<Item> Items { get;  }
        IEnumerable<Item> GetAction { get; }
        Item GetItemById(int ItemId);
    }
}
