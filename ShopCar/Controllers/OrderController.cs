using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopCar.Data.Interfaces;
using ShopCar.Models;

namespace ShopCar.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders _allOrders;
        private readonly ShopCart _shopCart;
        public OrderController(IAllOrders allOrder, ShopCart shopCart)
        {
            _allOrders = allOrder;
            _shopCart = shopCart;
        }



  

        [HttpGet]
        public IActionResult Checkout()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            _shopCart.ListShopItems = _shopCart.GetShopItems();
            if (_shopCart.ListShopItems.Count ==0)
            {
                ModelState.AddModelError("", "Դուք չունեք ընտրավծ ապրանք");
            }
            if (ModelState.IsValid)
            {
                _allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }
            return View(order);
        }
        public IActionResult Complete ()
        {
            ViewBag.massage = "Վճարումը հաջողությամբ կատարված է";

            return View();
        }
    }
}