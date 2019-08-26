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
    public class AcudientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcudientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acudientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acudiente.ToListAsync());
        }

        // GET: Acudientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acudiente = await _context.Acudiente
                .FirstOrDefaultAsync(m => m.AcudienteID == id);
            if (acudiente == null)
            {
                return NotFound();
            }

            return View(acudiente);
        }

        // GET: Acudientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acudientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcudienteID,Nombre,Apellido,Documento,Email,Telefono,Estado")] Acudiente acudiente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acudiente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acudiente);
        }

        // GET: Acudientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acudiente = await _context.Acudiente.FindAsync(id);
            if (acudiente == null)
            {
                return NotFound();
            }
            return View(acudiente);
        }

        // POST: Acudientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcudienteID,Nombre,Apellido,Documento,Email,Telefono,Estado")] Acudiente acudiente)
        {
            if (id != acudiente.AcudienteID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acudiente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcudienteExists(acudiente.AcudienteID))
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
            return View(acudiente);
        }

        // GET: Acudientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acudiente = await _context.Acudiente
                .FirstOrDefaultAsync(m => m.AcudienteID == id);
            if (acudiente == null)
            {
                return NotFound();
            }

            return View(acudiente);
        }

        // POST: Acudientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acudiente = await _context.Acudiente.FindAsync(id);
            _context.Acudiente.Remove(acudiente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcudienteExists(int id)
        {
            return _context.Acudiente.Any(e => e.AcudienteID == id);
        }
    }
}
