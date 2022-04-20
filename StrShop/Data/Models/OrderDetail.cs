using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }

        public int orderId { get; set; }

        public int ItemId { get; set; }

        public ushort price { get; set; }

        public virtual Item item { get; set; }

        public virtual Order order { get; set; }
    }
}
