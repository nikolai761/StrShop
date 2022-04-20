using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.ViewsModels
{
    public class SearchViewModel
    {
        public List<Item> items { get; set; }

        public string Text { get; set; }
    }
}