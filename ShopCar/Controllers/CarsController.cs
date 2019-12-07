using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopCar.Data.Interfaces;
using ShopCar.Models;
using ShopCar.ViewModels;

namespace ShopCar.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;
        private readonly ICarsCategory _carsCategory;
        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _carsCategory = carsCategory;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("Cars/List")]
        [Route("Cars/List/category")]
        public IActionResult List(string category)
        {

            string _category = category;
            IEnumerable<Car> Cars = null;
            string currCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                Cars = _allCars.Cars.OrderBy(c => c.Id);
            }
            else
            {
                if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
                {
                    Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Էլեկտրոմոբիլներ")).OrderBy(i => i.Id);
                    currCategory = "Էլեկտրոմոբիլներ";
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    Cars = _allCars.Cars.Where(c => c.Category.CategoryName.Equals("Դասական ավտոմեքենաներ")).OrderBy(i => i.Id);
                    currCategory = "Դասական ավտոմեքենաներ";
                }

            }

            CarsListViewModel cars = new CarsListViewModel
            {
                CurrCategory = currCategory,
                GetAllCars = Cars

            };


            ViewBag.Title = "Մեքենաներ";

            return View(cars);
        }
    }
}