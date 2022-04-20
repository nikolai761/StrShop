
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace StrShop.Data
{
    public class DBconnection : DbContext
    {
        public DBconnection(DbContextOptions<DBconnection> options) : base(options) { }

        public DbSet<Item> Item {get; set;}
        public DbSet<Category> Category { get; set; }
        public DbSet<Producer> Producer{ get; set; }
        public DbSet<Storage> Storage { get; set; }
        public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            var salt = new byte[64 / 8];
            rng.GetBytes(salt);
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: "123456",
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 128 / 8));


            modelBuilder.Entity<Role>().HasData(new Role[] { new Role { ID = 1, Name = "admin" }, new Role { ID = 2, Name = "user" } });
            modelBuilder.Entity<User>().HasData(new User[] { new User { ID = 1, Email = "admin", Password = hashed, RoleId = 1, Unblocked = true, salt = salt } });
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            base.OnModelCreating(modelBuilder);
        }
    } 
}
