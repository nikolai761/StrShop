using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class Storage
    {
        public int id { set; get; }

        public string StorageAddress { set; get; }

        public bool Delivery { set; get; }

        public List<Item> Items { set; get; }

    }
}
