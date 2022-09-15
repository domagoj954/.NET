using System.Collections;
using Company.Data;
using Microsoft.EntityFrameworkCore;

namespace Company.Models;

public class EmployeeService : IEmployeeService{

    public ApplicationDbContext Db { get; }

    public EmployeeService(ApplicationDbContext context)
    {
        Db = context;
    }


    public async Task<IEnumerable> IsOnProject()
    {
    return await Db.Employees.Where(employee => employee.IsOnProject == true).ToListAsync();
    }

    public async Task<IEnumerable> Programmers()
    {
    return await Db.Employees.Where(employee => employee.Profession == "Programmer").ToListAsync();
    }

}