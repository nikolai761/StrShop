using StrShop.Data;
using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace StrShop.Data.Repository
{
    public class UserRepository : IUsers
    {
        private readonly DBconnection dBconnection;


        public UserRepository(DBconnection dBconnection)
        {
            this.dBconnection = dBconnection;
        }

        public IEnumerable<User> AllUsers => dBconnection.User;


        public User ConfirmUser(string name, string pas) => dBconnection.User.FirstOrDefault(u => u.Email == name && u.Password == pas);

        public void CreateUser(User user) => dBconnection.User.Add(user);

        public int GetUserIdByName(string name) => dBconnection.User.FirstOrDefault(u => u.Email == name).ID;


        public void DeleteUser(User user) => dBconnection.User.Remove(user);

        public User GetUser(int id) => dBconnection.User.FirstOrDefault(u => u.ID == id);

        public void SaveDB() => dBconnection.SaveChanges();

        public User WithSameName(string name) => dBconnection.User.FirstOrDefault(u => u.Email == name);
    }
}
