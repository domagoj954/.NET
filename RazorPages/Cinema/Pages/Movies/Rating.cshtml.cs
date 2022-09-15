#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cinema.Models;

namespace Cinema.Pages_Movies
{
    public class RatingModel : PageModel
    {
        private readonly CinemaDbContext _context;

        public RatingModel(CinemaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = from movie in _context.Movie where movie.Rating >= 9.7 select movie;
        }
    }
}
