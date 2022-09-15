#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

    public class CinemaDbContext : DbContext
    {
        public CinemaDbContext (DbContextOptions<CinemaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cinema.Models.Movie> Movie { get; set; }
    }
