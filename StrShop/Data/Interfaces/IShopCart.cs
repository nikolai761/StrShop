using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Interfaces
{
    public interface IShopCart
    {
        string ShopCartId { get; set; }

        List<ShopCartItem> ListShopItems { get; set; }

        ShopCart GetCart(IServiceProvider services);

        void AddToCart(Item item);

        void DeleteFromCart();

        List<ShopCartItem> GetShopItems();


    }
}
