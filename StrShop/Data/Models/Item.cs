using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class Item
    {
        public int id { set; get; }

        public int CategoryId { set; get; }

        public int ProducerId { set; get; }

        public int StorageId { set; get; }

        public string ItemName { set; get; }

        public ushort price { set; get; }

        public string img { set; get; }

        public bool isAction { set; get; }

        public virtual Category Category    { set; get; }

        public virtual Producer Producer { set; get; }

        public virtual Storage Storage { set; get; }

        public string Description { set; get; }

    }
}
