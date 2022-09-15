using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarShopAPI.Models
{
    public class Car
    {
      public int Id { get; set; }

      public int ShopId { get; set; }

      public string? Model { get; set; } 

      int YearOfProduction { get; set; }
      public string? Color { get; set; }

      public string? Price { get; set; }


    }
}