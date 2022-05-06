using Microsoft.AspNetCore.Mvc;
using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using StrShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;




namespace StrShop.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllItems _itemRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllItems itemRepository, ShopCart shopCart)
        {
            _itemRepository = itemRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            ViewBag.Title = "Корзина ";
            var items = _shopCart.GetShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel { shopCart = _shopCart };

            return View(obj);
        }




        public RedirectResult addToCart(int id)
        {
            var item = _itemRepository.Items.FirstOrDefault(i => i.id == id);

            if (item != null) { _shopCart.AddToCart(item); }

            return Redirect("/Items/ItemList");

        }

        public RedirectResult Delete(int id)
        {
            _shopCart.DeleteByID(id);
            return Redirect("/ShopCart/Index");
        }
    }
}
