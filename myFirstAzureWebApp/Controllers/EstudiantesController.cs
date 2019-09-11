using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using myFirstAzureWebApp.Data;
using myFirstAzureWebApp.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace myFirstAzureWebApp.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment he;

        public EstudiantesController(ApplicationDbContext context, IHostingEnvironment e)
        {
            _context = context;
            he = e;
        }

        // GET: Estudiantes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Estudiante.Include(e => e.Acudiente);
            return View(await applicationDbContext.ToListAsync());
        }
        public IActionResult Jugadores()
        {
            
            return View();
        }

        // GET: Estudiantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
                .Include(e => e.Acudiente)
                .FirstOrDefaultAsync(m => m.EstudianteID == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // GET: Estudiantes/Create
        public IActionResult Create()
        {
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre");
            
            return View();
        }

        // POST: Estudiantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EstudianteID,AcudienteID,Nombre,Apellido,Documento,FechaNacimiento")] Estudiante estudiante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction("Contact", "Home");
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre", estudiante.AcudienteID);
            return View(estudiante);
        }

        // GET: Estudiantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante.FindAsync(id);
            if (estudiante == null)
            {
                return NotFound();
            }
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre", estudiante.AcudienteID);
            return View(estudiante);
        }

        // POST: Estudiantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EstudianteID,AcudienteID,Nombre,Apellido,Documento,FechaNacimiento")] Estudiante estudiante)
        {
            if (id != estudiante.EstudianteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudiante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudianteExists(estudiante.EstudianteID))
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
            ViewData["AcudienteID"] = new SelectList(_context.Acudiente, "AcudienteID", "Nombre", estudiante.AcudienteID);
            return View(estudiante);
        }

        // GET: Estudiantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var estudiante = await _context.Estudiante
                .Include(e => e.Acudiente)
                .FirstOrDefaultAsync(m => m.EstudianteID == id);
            if (estudiante == null)
            {
                return NotFound();
            }

            return View(estudiante);
        }

        // POST: Estudiantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var estudiante = await _context.Estudiante.FindAsync(id);
            _context.Estudiante.Remove(estudiante);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstudianteExists(int id)
        {
            return _context.Estudiante.Any(e => e.EstudianteID == id);
        }
        public async Task<IActionResult> Leones(string fullName, IFormFile PhotoPath)
        {
            ViewData["fname"] = fullName;
            if (PhotoPath != null)
            {
                var fileName = Path.Combine(he.WebRootPath, Path.GetFileName(PhotoPath.FileName));
                PhotoPath.CopyTo(new FileStream(fileName, FileMode.Create));
                ViewData["fileLocation"] = "/" + Path.GetFileName(PhotoPath.FileName);
            }
            var applicationDbContext = _context.Estudiante.Include(e => e.Acudiente);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Zebras()
        {
            var applicationDbContext = _context.Estudiante.Include(e => e.Acudiente);
            return View(await applicationDbContext.ToListAsync());
        }
        public async Task<IActionResult> Gladiadores()
        {
            var applicationDbContext = _context.Estudiante.Include(e => e.Acudiente);
            return View(await applicationDbContext.ToListAsync());
        }
    }
}
