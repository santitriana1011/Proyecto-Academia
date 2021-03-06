﻿using System;
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
using myFirstAzureWebApp.ViewModels;

namespace myFirstAzureWebApp.Controllers
{
    public class EstudiantesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment hostingEnvironment;

        public EstudiantesController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this.hostingEnvironment = hostingEnvironment;
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
        public async Task<IActionResult> Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;
                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                Estudiante newEstudiante = new Estudiante
                {
                    AcudienteID = model.AcudienteID,
                    Nombre = model.Nombre,
                    Apellido = model.Apellido,
                    Documento = model.Documento,
                    FechaNacimiento = model.FechaNacimiento,
                    PhotoPath = uniqueFileName
                };
                _context.Add(newEstudiante);
                await _context.SaveChangesAsync();
                return RedirectToAction("Leones");
            }
            return View();
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
        public async Task<IActionResult> Leones()
        {
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
