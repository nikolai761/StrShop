using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Repository
{
    public class ProducerRepository : IProducer
    {
        private readonly DBconnection dBconnection;

        public ProducerRepository(DBconnection dBconnection) { this.dBconnection = dBconnection; }

        public IEnumerable<Producer> AllProducers => dBconnection.Producer;
    }
}
