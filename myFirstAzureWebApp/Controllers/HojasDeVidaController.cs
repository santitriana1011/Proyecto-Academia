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
    public class HojasDeVidaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HojasDeVidaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HojasDeVida
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.HojaDeVida.Include(h => h.Empleado);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: HojasDeVida/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaDeVida = await _context.HojaDeVida
                .Include(h => h.Empleado)
                .FirstOrDefaultAsync(m => m.HojaDeVidaID == id);
            if (hojaDeVida == null)
            {
                return NotFound();
            }

            return View(hojaDeVida);
        }

        // GET: HojasDeVida/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre");
            return View();
        }

        // POST: HojasDeVida/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HojaDeVidaID,EmpleadoID,Especialidad,TiempoExperiencia")] HojaDeVida hojaDeVida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hojaDeVida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", hojaDeVida.EmpleadoID);
            return View(hojaDeVida);
        }

        // GET: HojasDeVida/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaDeVida = await _context.HojaDeVida.FindAsync(id);
            if (hojaDeVida == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", hojaDeVida.EmpleadoID);
            return View(hojaDeVida);
        }

        // POST: HojasDeVida/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HojaDeVidaID,EmpleadoID,Especialidad,TiempoExperiencia")] HojaDeVida hojaDeVida)
        {
            if (id != hojaDeVida.HojaDeVidaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hojaDeVida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HojaDeVidaExists(hojaDeVida.HojaDeVidaID))
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
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", hojaDeVida.EmpleadoID);
            return View(hojaDeVida);
        }

        // GET: HojasDeVida/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hojaDeVida = await _context.HojaDeVida
                .Include(h => h.Empleado)
                .FirstOrDefaultAsync(m => m.HojaDeVidaID == id);
            if (hojaDeVida == null)
            {
                return NotFound();
            }

            return View(hojaDeVida);
        }

        // POST: HojasDeVida/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hojaDeVida = await _context.HojaDeVida.FindAsync(id);
            _context.HojaDeVida.Remove(hojaDeVida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HojaDeVidaExists(int id)
        {
            return _context.HojaDeVida.Any(e => e.HojaDeVidaID == id);
        }
    }
}
