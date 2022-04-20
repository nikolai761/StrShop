using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.ViewModels
{
    public class UsersListViewModel
    {
        public IEnumerable<User> GetUsers { get; set; }
    }
}
