using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.ViewModels
{
    public class ItemListViewModel
    {
        public IEnumerable<Item> AllItems { get; set; }
         
        public string ItemCategory { get; set; }

        public string ItemProducer { get; set; }
    }

}
