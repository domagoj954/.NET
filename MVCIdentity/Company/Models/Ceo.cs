using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Ceo
    {
        public int Id { get; set; }

        public string? Name { get; set; }   

        public string? LastName { get; set; }

        public List<Employee>? Employees { get; set; }
    }
}