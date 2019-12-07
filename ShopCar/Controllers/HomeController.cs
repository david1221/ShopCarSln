using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopCar.Data.Interfaces;
using ShopCar.Models;
using ShopCar.ViewModels;

namespace ShopCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars _carRep;
       
        public HomeController(IAllCars carRep)
        {
            _carRep = carRep;
   
        }
        public IActionResult Index()
        {
            var homeCars = new HomeViewModels
            {
                FavCars = _carRep.GetFavCars
            };
            return View(homeCars);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
