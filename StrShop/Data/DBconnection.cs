using Microsoft.EntityFrameworkCore;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    } 
}
