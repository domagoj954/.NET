using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Company.Data;
using Company.Models;

namespace Company.Controllers
{
    public class CeosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CeosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ceos
        public async Task<IActionResult> Index()
        {
              return _context.Ceos != null ? 
                          View(await _context.Ceos.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Ceos'  is null.");
        }

        // GET: Ceos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ceos == null)
            {
                return NotFound();
            }

            var ceo = await _context.Ceos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ceo == null)
            {
                return NotFound();
            }

            return View(ceo);
        }

        // GET: Ceos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ceos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName")] Ceo ceo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ceo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ceo);
        }

        // GET: Ceos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ceos == null)
            {
                return NotFound();
            }

            var ceo = await _context.Ceos.FindAsync(id);
            if (ceo == null)
            {
                return NotFound();
            }
            return View(ceo);
        }

        // POST: Ceos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName")] Ceo ceo)
        {
            if (id != ceo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ceo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CeoExists(ceo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ceo);
        }

        // GET: Ceos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ceos == null)
            {
                return NotFound();
            }

            var ceo = await _context.Ceos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ceo == null)
            {
                return NotFound();
            }

            return View(ceo);
        }

        // POST: Ceos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ceos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Ceos'  is null.");
            }
            var ceo = await _context.Ceos.FindAsync(id);
            if (ceo != null)
            {
                _context.Ceos.Remove(ceo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CeoExists(int id)
        {
          return (_context.Ceos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
