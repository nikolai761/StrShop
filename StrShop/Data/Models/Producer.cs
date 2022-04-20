using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class Producer
    {
        public int id { set; get; }

        public string ProducerName { set; get; }

        public string ProducerDesc { set; get; }

        public List<Item> Items { set; get; }
    }
}
