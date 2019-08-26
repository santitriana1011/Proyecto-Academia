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
    public class NovedadesMedicasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NovedadesMedicasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: NovedadesMedicas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.NovedadMedica.Include(n => n.Empleado).Include(n => n.Estudiante);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: NovedadesMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novedadMedica = await _context.NovedadMedica
                .Include(n => n.Empleado)
                .Include(n => n.Estudiante)
                .FirstOrDefaultAsync(m => m.NovedadMedicaID == id);
            if (novedadMedica == null)
            {
                return NotFound();
            }

            return View(novedadMedica);
        }

        // GET: NovedadesMedicas/Create
        public IActionResult Create()
        {
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre");
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre");
            return View();
        }

        // POST: NovedadesMedicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NovedadMedicaID,EstudianteID,EmpleadoID,FechaLesion,Descripcion")] NovedadMedica novedadMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(novedadMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", novedadMedica.EmpleadoID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre", novedadMedica.EstudianteID);
            return View(novedadMedica);
        }

        // GET: NovedadesMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novedadMedica = await _context.NovedadMedica.FindAsync(id);
            if (novedadMedica == null)
            {
                return NotFound();
            }
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", novedadMedica.EmpleadoID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre", novedadMedica.EstudianteID);
            return View(novedadMedica);
        }

        // POST: NovedadesMedicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NovedadMedicaID,EstudianteID,EmpleadoID,FechaLesion,Descripcion")] NovedadMedica novedadMedica)
        {
            if (id != novedadMedica.NovedadMedicaID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(novedadMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NovedadMedicaExists(novedadMedica.NovedadMedicaID))
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
            ViewData["EmpleadoID"] = new SelectList(_context.Empleado, "EmpleadoID", "Nombre", novedadMedica.EmpleadoID);
            ViewData["EstudianteID"] = new SelectList(_context.Estudiante, "EstudianteID", "Nombre", novedadMedica.EstudianteID);
            return View(novedadMedica);
        }

        // GET: NovedadesMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var novedadMedica = await _context.NovedadMedica
                .Include(n => n.Empleado)
                .Include(n => n.Estudiante)
                .FirstOrDefaultAsync(m => m.NovedadMedicaID == id);
            if (novedadMedica == null)
            {
                return NotFound();
            }

            return View(novedadMedica);
        }

        // POST: NovedadesMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var novedadMedica = await _context.NovedadMedica.FindAsync(id);
            _context.NovedadMedica.Remove(novedadMedica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NovedadMedicaExists(int id)
        {
            return _context.NovedadMedica.Any(e => e.NovedadMedicaID == id);
        }
    }
}
