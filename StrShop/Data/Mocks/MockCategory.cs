using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Mocks
{
    public class MockCategory : IItemCategory
    {
        public IEnumerable<Category> AllCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category{ CategoryName ="Смеси"},
                    new Category{ CategoryName ="Краски"},
                };
            }
        }
    }
}
