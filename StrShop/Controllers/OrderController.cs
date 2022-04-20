using Microsoft.AspNetCore.Mvc;
using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.allOrders = allOrders;
            this.shopCart = shopCart;
        }

        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            shopCart.ListShopItems = shopCart.GetShopItems();
            if(shopCart.ListShopItems.Count==0)
            {
                ModelState.AddModelError("", "Нет товаров");
            }

            if(ModelState.IsValid)
            {
                allOrders.createOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            shopCart.DeleteFromCart();
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }
    }
}
