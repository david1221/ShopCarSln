using ShopCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCar.ViewModels
{
    public class HomeViewModels
    {
        public IEnumerable<Car> FavCars { get; set; }
    }
}
