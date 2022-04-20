using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Interfaces
{
    public interface IUsers
    {
        IEnumerable<User> AllUsers { get; }

        void CreateUser(User user);

        User ConfirmUser(string name, string pas);

        User WithSameName(string name);

        User GetUser(int id);

        int GetUserIdByName(string name);

        void DeleteUser(User user);

        void SaveDB();
    }
}
