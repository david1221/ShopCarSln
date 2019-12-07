using ShopCar.Data.Interfaces;
using ShopCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCar.Data.Repozitory
{
    public class OrdersRepozitory : IAllOrders
    {
        private readonly AppDBContent _appDBContent;
        private readonly ShopCart _shopCart;

        public OrdersRepozitory(AppDBContent appDBContent, ShopCart shopCart)
        {
            _appDBContent = appDBContent;
            _shopCart = shopCart;
        }
        public void CreateOrder(Order order)
        {
            order.OrderTime = DateTime.Now;
            _appDBContent.Orders.Add(order);

            var items = _shopCart.ListShopItems;
            foreach (var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    CarId = el.Car.Id,
                    OrderId = order.Id,
                    Price = el.Car.Price

                };
                _appDBContent.OrderDetails.Add(orderDetail);
            }
            _appDBContent.SaveChanges();
        }
    }
}
