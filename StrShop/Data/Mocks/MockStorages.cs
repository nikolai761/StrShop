using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Mocks
{
    public class MockStorages : IStorages
    {
        public IEnumerable<Storage> AllStorages
        {
            get
            {
                return new List<Storage>
                {
                    new Storage{ StorageAddress = "Уручье"},
                    new Storage{ StorageAddress = "Лошица"}
                };
            }
        }
    }
}
