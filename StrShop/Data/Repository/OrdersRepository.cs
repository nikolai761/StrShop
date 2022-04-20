using StrShop.Data.Interfaces;
using StrShop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly DBconnection dBconnection;
        private readonly ShopCart shopCart;

        public OrdersRepository(DBconnection dBconnection, ShopCart shopCart)
        {
            this.dBconnection = dBconnection;
            this.shopCart = shopCart;
        }

        public void createOrder(Order order)
        {
            dBconnection.Order.Add(order);

            var items = shopCart.ListShopItems;

            foreach(var el in items)
            {
                var orderDtails = new OrderDetail()
                {
                    ItemId = el.item.id,
                    orderId=order.id,
                    price=el.item.price
                };
                dBconnection.OrderDetail.Add(orderDtails);
            }
            dBconnection.SaveChanges();
        }
    }
}

