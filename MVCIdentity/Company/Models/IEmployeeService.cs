using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Data;

namespace Company.Models
{
    public interface IEmployeeService
    {
        Task<IEnumerable> IsOnProject();

        Task<IEnumerable> Programmers();
        ApplicationDbContext Db { get; }
        
    }
}