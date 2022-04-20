using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Mocks
{
    public class MockProducers : IProducer
    {
        public IEnumerable<Producer> AllProducers
        {
            get
            {
                return new List<Producer>
                {
                    new Producer{  ProducerName = "Sniezka"  },
                    new Producer{  ProducerName = "Condor"  }
                };
            }
        }

       
    }
}
