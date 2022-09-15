using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Company.Models;

namespace Company.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Company.Models.Employee>? Employees { get; set; }
    public DbSet<Company.Models.Ceo>? Ceos { get; set; }
}
