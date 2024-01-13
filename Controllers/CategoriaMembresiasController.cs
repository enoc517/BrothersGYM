using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BrothersGYM.Data;
using BrothersGYM.Models;

namespace BrothersGYM.Controllers
{
    public class CategoriaMembresiasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaMembresiasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaMembresias
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaMembresia.ToListAsync());
        }

        // GET: CategoriaMembresias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMembresium = await _context.CategoriaMembresia
                .FirstOrDefaultAsync(m => m.IdcategoriaMembresia == id);
            if (categoriaMembresium == null)
            {
                return NotFound();
            }

            return View(categoriaMembresium);
        }

        // GET: CategoriaMembresias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaMembresias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcategoriaMembresia,Descripcion,Precio")] CategoriaMembresium categoriaMembresium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaMembresium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaMembresium);
        }

        // GET: CategoriaMembresias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMembresium = await _context.CategoriaMembresia.FindAsync(id);
            if (categoriaMembresium == null)
            {
                return NotFound();
            }
            return View(categoriaMembresium);
        }

        // POST: CategoriaMembresias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcategoriaMembresia,Descripcion,Precio")] CategoriaMembresium categoriaMembresium)
        {
            if (id != categoriaMembresium.IdcategoriaMembresia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaMembresium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaMembresiumExists(categoriaMembresium.IdcategoriaMembresia))
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
            return View(categoriaMembresium);
        }

        // GET: CategoriaMembresias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaMembresium = await _context.CategoriaMembresia
                .FirstOrDefaultAsync(m => m.IdcategoriaMembresia == id);
            if (categoriaMembresium == null)
            {
                return NotFound();
            }

            return View(categoriaMembresium);
        }

        // POST: CategoriaMembresias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaMembresium = await _context.CategoriaMembresia.FindAsync(id);
            if (categoriaMembresium != null)
            {
                _context.CategoriaMembresia.Remove(categoriaMembresium);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaMembresiumExists(int id)
        {
            return _context.CategoriaMembresia.Any(e => e.IdcategoriaMembresia == id);
        }
    }
}
