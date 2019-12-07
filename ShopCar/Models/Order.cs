using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCar.Models
{
    public class Order
    {   [BindNever]
        public int Id { get; set; }

        [Display(Name="Գրեք Անունը")]
       [MinLength(3)]
       [Required(ErrorMessage ="Անունը իչ կարող լինել 3 նիշից պակաս ")]
        public string Name { get; set; }

        [Display(Name = "Գրեք հայրանունը")]
        [MinLength(3)]
        [Required(ErrorMessage = "հայրանունը իչ կարող լինել 3 նիշից պակաս ")]
        public string Surname { get; set; }

        [Display(Name = "Գրեք Հասցեն")]
        [MinLength(5)]
        [Required(ErrorMessage = "Հասցեն իչ կարող լինել 5 նիշից պակաս ")]
        public string Adress { get; set; }

        [Display(Name = "Գրեք Հեռախոսահամարը")]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "հեռախոսահամարը իչ կարող լինել 6 նիշից պակաս ")]
        public string Phone { get; set; }

        [Display(Name = "Գրեք Անունը")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Էլ․ հասցեն իչ կարող լինել 5 նիշից պակաս ")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderTime { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }
    }
}
