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
    public class ActualidadesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ActualidadesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Actualidades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Actualidad.ToListAsync());
        }

        // GET: Actualidades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualidad = await _context.Actualidad
                .FirstOrDefaultAsync(m => m.ActualidadID == id);
            if (actualidad == null)
            {
                return NotFound();
            }

            return View(actualidad);
        }

        // GET: Actualidades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actualidades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ActualidadID,Nombre,Fecha,Descripcion")] Actualidad actualidad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(actualidad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actualidad);
        }

        // GET: Actualidades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualidad = await _context.Actualidad.FindAsync(id);
            if (actualidad == null)
            {
                return NotFound();
            }
            return View(actualidad);
        }

        // POST: Actualidades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ActualidadID,Nombre,Fecha,Descripcion")] Actualidad actualidad)
        {
            if (id != actualidad.ActualidadID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(actualidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActualidadExists(actualidad.ActualidadID))
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
            return View(actualidad);
        }

        // GET: Actualidades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actualidad = await _context.Actualidad
                .FirstOrDefaultAsync(m => m.ActualidadID == id);
            if (actualidad == null)
            {
                return NotFound();
            }

            return View(actualidad);
        }

        // POST: Actualidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actualidad = await _context.Actualidad.FindAsync(id);
            _context.Actualidad.Remove(actualidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActualidadExists(int id)
        {
            return _context.Actualidad.Any(e => e.ActualidadID == id);
        }
    }
}
