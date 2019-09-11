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
    public class EncuentrosController : Controller
    {
        public IActionResult Matches()
        {
            return View();
        }

        private readonly ApplicationDbContext _context;

        public EncuentrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        

        // GET: Encuentros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Encuentros.Include(e => e.Escuela);
            return View(await applicationDbContext.ToListAsync());
        }

        
        // GET: Encuentros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentros = await _context.Encuentros
                .FirstOrDefaultAsync(m => m.EncuentrosID == id);
            if (encuentros == null)
            {
                return NotFound();
            }

            return View(encuentros);
        }

        // GET: Encuentros/Create
        public IActionResult Create()
        {
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre");
            return View();
        }

        // POST: Encuentros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EncuentrosID,EscuelaID,Categoria,NombreEvento,Descripcion")] Encuentros encuentros)
        {
            if (ModelState.IsValid)
            {
                _context.Add(encuentros);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre", encuentros.EscuelaID);
            return View(encuentros);
            
            
        }

        // GET: Encuentros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentros = await _context.Encuentros.FindAsync(id);
            if (encuentros == null)
            {
                return NotFound();
            }
            ViewData["EscuelaID"] = new SelectList(_context.Escuela, "EscuelaID", "Nombre", encuentros.EscuelaID);
            return View(encuentros);
        }

        // POST: Encuentros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EncuentrosID,EscuelaID,Categoria,NombreEvento,Descripcion")] Encuentros encuentros)
        {
            if (id != encuentros.EncuentrosID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(encuentros);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EncuentrosExists(encuentros.EncuentrosID))
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
            return View(encuentros);
        }

        // GET: Encuentros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var encuentros = await _context.Encuentros
                .FirstOrDefaultAsync(m => m.EncuentrosID == id);
            if (encuentros == null)
            {
                return NotFound();
            }

            return View(encuentros);
        }

        // POST: Encuentros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var encuentros = await _context.Encuentros.FindAsync(id);
            _context.Encuentros.Remove(encuentros);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EncuentrosExists(int id)
        {
            return _context.Encuentros.Any(e => e.EncuentrosID == id);
        }
    }
}
