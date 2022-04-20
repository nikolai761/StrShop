using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StrShop.Data.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }

        [Display(Name="Введите имя")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        public string adress { get; set; }

        [Display(Name = "Введите номер")]
        [DataType(DataType.PhoneNumber)]
        public string phone { get; set; }

        [Display(Name = "Введите email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        
        public  List<OrderDetail> OrderDelails { get; set; }

    }
}
