using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Repository
{
    public class StoragesRepository : IStorages
    {
        private readonly DBconnection dBconnection;

        public StoragesRepository(DBconnection dBconnection) { this.dBconnection = dBconnection; }

        public IEnumerable<Storage> AllStorages => dBconnection.Storage;
    }
}

