using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class Category
    {
        public int id { set; get; }

        public string CategoryName { set; get; }

        public List<Item> Items { set; get; }

    }
}
