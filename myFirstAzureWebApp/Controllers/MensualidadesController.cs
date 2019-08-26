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
    public class MensualidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MensualidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Mensualidades
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Mensualidad.Include(m => m.Acudiente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Mensualidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensualidad = await _context.Mensualidad
                .Include(m => m.Acudiente)
                .FirstOrDefaultAsync(m => m.MensualidadID == id);
            if (mensualidad == null)
            {
                return NotFound();
            }

            return View(mensualidad);
        }

        // GET: Mensualidades/Create
        public IActionResult Create()
        {
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre");
            return View();
        }

        // POST: Mensualidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MensualidadID,AcudienteID,FechaPago,Valor,Mes,Anio")] Mensualidad mensualidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mensualidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre", mensualidad.AcudienteID);
            return View(mensualidad);
        }

        // GET: Mensualidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensualidad = await _context.Mensualidad.FindAsync(id);
            if (mensualidad == null)
            {
                return NotFound();
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre", mensualidad.AcudienteID);
            return View(mensualidad);
        }

        // POST: Mensualidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MensualidadID,AcudienteID,FechaPago,Valor,Mes,Anio")] Mensualidad mensualidad)
        {
            if (id != mensualidad.MensualidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mensualidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MensualidadExists(mensualidad.MensualidadID))
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
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre", mensualidad.AcudienteID);
            return View(mensualidad);
        }

        // GET: Mensualidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mensualidad = await _context.Mensualidad
                .Include(m => m.Acudiente)
                .FirstOrDefaultAsync(m => m.MensualidadID == id);
            if (mensualidad == null)
            {
                return NotFound();
            }

            return View(mensualidad);
        }

        // POST: Mensualidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mensualidad = await _context.Mensualidad.FindAsync(id);
            _context.Mensualidad.Remove(mensualidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MensualidadExists(int id)
        {
            return _context.Mensualidad.Any(e => e.MensualidadID == id);
        }
    }
}
