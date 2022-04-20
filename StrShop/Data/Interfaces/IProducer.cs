using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Interfaces
{
    interface IProducer
    {
        IEnumerable<Producer> AllProducers { get; }
    }
}
