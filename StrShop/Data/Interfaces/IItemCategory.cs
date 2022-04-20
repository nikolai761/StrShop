using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Interfaces
{
    public interface IItemCategory
    {
        IEnumerable<Category> AllCategories { get; }
    }


}
