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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService es;

        public EmployeesController(IEmployeeService es)
        {
            this.es = es;
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = es.Db.Employees.Include(e => e.Ceo);
            return View(await es.Db.Employees.ToListAsync());
        }

        public async Task<IActionResult> IsOnProject()
        {
            return View(await es.IsOnProject());
        }

        public async Task<IActionResult> Programmers()
        {
            return View(await es.Programmers());
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || es.Db.Employees == null)
            {
                return NotFound();
            }

            var employee = await es.Db.Employees
                .Include(e => e.Ceo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["CeoId"] = new SelectList(es.Db.Ceos, "Id", "Id");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,LastName,Age,Profession,IsOnProject,CeoId")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                es.Db.Add(employee);
                await es.Db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CeoId"] = new SelectList(es.Db.Ceos, "Id", "Id", employee.CeoId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || es.Db.Employees == null)
            {
                return NotFound();
            }

            var employee = await es.Db.Employees.FindAsync(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["CeoId"] = new SelectList(es.Db.Ceos, "Id", "Id", employee.CeoId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,LastName,Age,Profession,IsOnProject,CeoId")] Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    es.Db.Update(employee);
                    await es.Db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
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
            ViewData["CeoId"] = new SelectList(es.Db.Ceos, "Id", "Id", employee.CeoId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || es.Db.Employees == null)
            {
                return NotFound();
            }

            var employee = await es.Db.Employees
                .Include(e => e.Ceo)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (es.Db.Employees == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Employees'  is null.");
            }
            var employee = await es.Db.Employees.FindAsync(id);
            if (employee != null)
            {
                es.Db.Employees.Remove(employee);
            }
            
            await es.Db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
          return (es.Db.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
