using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class ShopCart
    {

        private readonly DBconnection dBconnection;

        public ShopCart(DBconnection dBconnection) { this.dBconnection = dBconnection; }

        public string ShopCartId { get; set; }

        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
             ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<DBconnection>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();
            session.SetString("CartId", shopCartId);

            return new ShopCart(context) { ShopCartId = shopCartId };
        }

        public void AddToCart(Item item )
        {
            this.dBconnection.ShopCartItems.Add(new ShopCartItem
            {
                ShopCartId = ShopCartId,
                item = item,
                price = item.price
            });

            dBconnection.SaveChanges();
        }

        public void DeleteFromCart()
        {
            foreach (ShopCartItem  el in GetShopItems())
                this.dBconnection.ShopCartItems.Remove(el);
           

            dBconnection.SaveChanges(); 
        }

        public List<ShopCartItem> GetShopItemById(int id)
        {
            return dBconnection.ShopCartItems.Where(c => c.item.id == id).Include(s => s.item).ToList();
        }

        public List<ShopCartItem> GetShopItems()
        {
            return dBconnection.ShopCartItems.Where(c => c.ShopCartId == ShopCartId).Include(s => s.item).ToList();
        }

        public void DeleteByID(int id)
        {
            foreach (ShopCartItem el in GetShopItemById(id))
                this.dBconnection.ShopCartItems.Remove(el);
            dBconnection.SaveChanges();
        }

    }
}
 