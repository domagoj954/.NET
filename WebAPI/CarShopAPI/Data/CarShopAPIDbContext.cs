using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarShopAPI.Models;

    public class CarShopAPIDbContext : DbContext
    {
        public CarShopAPIDbContext (DbContextOptions<CarShopAPIDbContext> options)
            : base(options)
        {
        }
        public DbSet<CarShopAPI.Models.Shop>? Shop { get; set; }
        public DbSet<CarShopAPI.Models.Car>? Car { get; set; }



    }
