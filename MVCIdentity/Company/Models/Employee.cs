using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; } 

        public string? Name { get; set; }   

        public string? LastName { get; set; } 

        public int Age { get; set; } 

        public string? Profession { get; set; } 

        public bool  IsOnProject { get; set; }
        

        public int CeoId { get; set; }
        public Ceo? Ceo { get; set; }
    }
}