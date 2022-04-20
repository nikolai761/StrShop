using Microsoft.EntityFrameworkCore;
using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Repository
{
    public class CategoryRepository : IItemCategory
    {
        private readonly DBconnection dBconnection;

       public CategoryRepository(DBconnection dBconnection) { this.dBconnection = dBconnection; }

        public IEnumerable<Category> AllCategories => dBconnection.Category;
    }
}
