using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using CarShopAPI.Models;

namespace CarShopAPI.Models
{
    public class Shop
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }    

        public string? Address { get; set; } 

        public int PhoneNumber { get; set; }    

        public string? CEO { get; set; }

        public List<Car>? Cars { get; set; }

    }
}