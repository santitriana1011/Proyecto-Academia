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
    public class TraspasosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TraspasosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Traspasos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Traspaso.Include(t => t.Escuela).Include(t => t.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Traspasos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traspaso = await _context.Traspaso
                .Include(t => t.Escuela)
                .Include(t => t.Estudiante)
                .FirstOrDefaultAsync(m => m.TraspasoID == id);
            if (traspaso == null)
            {
                return NotFound();
            }

            return View(traspaso);
        }

        // GET: Traspasos/Create
        public IActionResult Create()
        {
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre");
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre");
            return View();
        }

        // POST: Traspasos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TraspasoID,EstudianteID,EscuelaID,FechaInicio,FechaFin,Novedades")] Traspaso traspaso)
        {
            if (ModelState.IsValid)
            {
                _context.Add(traspaso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre", traspaso.EscuelaID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre", traspaso.EstudianteID);
            return View(traspaso);
        }

        // GET: Traspasos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traspaso = await _context.Traspaso.FindAsync(id);
            if (traspaso == null)
            {
                return NotFound();
            }
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre", traspaso.EscuelaID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre", traspaso.EstudianteID);
            return View(traspaso);
        }

        // POST: Traspasos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TraspasoID,EstudianteID,EscuelaID,FechaInicio,FechaFin,Novedades")] Traspaso traspaso)
        {
            if (id != traspaso.TraspasoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(traspaso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraspasoExists(traspaso.TraspasoID))
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
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre", traspaso.EscuelaID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre", traspaso.EstudianteID);
            return View(traspaso);
        }

        // GET: Traspasos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var traspaso = await _context.Traspaso
                .Include(t => t.Escuela)
                .Include(t => t.Estudiante)
                .FirstOrDefaultAsync(m => m.TraspasoID == id);
            if (traspaso == null)
            {
                return NotFound();
            }

            return View(traspaso);
        }

        // POST: Traspasos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var traspaso = await _context.Traspaso.FindAsync(id);
            _context.Traspaso.Remove(traspaso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraspasoExists(int id)
        {
            return _context.Traspaso.Any(e => e.TraspasoID == id);
        }
    }
}
