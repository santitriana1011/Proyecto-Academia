using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myFirstAzureWebApp.Data;
using myFirstAzureWebApp.Models;

namespace myFirstAzureWebApp.Controllers
{
    public class NominasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NominasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nominas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Nomina.Include(n => n.Empleado).Include(n => n.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Nominas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nomina
                .Include(n => n.Empleado)
                .Include(n => n.Item)
                .FirstOrDefaultAsync(m => m.NominaID == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // GET: Nominas/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre");
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "Nombre");
            return View();
        }

        // POST: Nominas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NominaID,EmpleadoID,ItemID,FechaInicio,FechaFin,Valor")] Nomina nomina)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nomina);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", nomina.EmpleadoID);
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "Nombre", nomina.ItemID);
            return View(nomina);
        }

        // GET: Nominas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nomina.FindAsync(id);
            if (nomina == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", nomina.EmpleadoID);
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "Nombre", nomina.ItemID);
            return View(nomina);
        }

        // POST: Nominas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NominaID,EmpleadoID,ItemID,FechaInicio,FechaFin,Valor")] Nomina nomina)
        {
            if (id != nomina.NominaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nomina);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NominaExists(nomina.NominaID))
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
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", nomina.EmpleadoID);
            ViewData["ItemID"] = new SelectList(_context.Item, "ItemID", "Nombre", nomina.ItemID);
            return View(nomina);
        }

        // GET: Nominas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nomina = await _context.Nomina
                .Include(n => n.Empleado)
                .Include(n => n.Item)
                .FirstOrDefaultAsync(m => m.NominaID == id);
            if (nomina == null)
            {
                return NotFound();
            }

            return View(nomina);
        }

        // POST: Nominas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nomina = await _context.Nomina.FindAsync(id);
            _context.Nomina.Remove(nomina);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NominaExists(int id)
        {
            return _context.Nomina.Any(e => e.NominaID == id);
        }
    }
}
