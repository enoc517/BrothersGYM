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
    public class CategoriaProductosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriaProductosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriaProductos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaProductos.ToListAsync());
        }

        // GET: CategoriaProductos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProductos
                .FirstOrDefaultAsync(m => m.IdcategoriaProducto == id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return View(categoriaProducto);
        }

        // GET: CategoriaProductos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriaProductos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdcategoriaProducto,Nombre,Descripcion")] CategoriaProducto categoriaProducto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaProducto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaProducto);
        }

        // GET: CategoriaProductos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }
            return View(categoriaProducto);
        }

        // POST: CategoriaProductos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdcategoriaProducto,Nombre,Descripcion")] CategoriaProducto categoriaProducto)
        {
            if (id != categoriaProducto.IdcategoriaProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaProducto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaProductoExists(categoriaProducto.IdcategoriaProducto))
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
            return View(categoriaProducto);
        }

        // GET: CategoriaProductos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaProducto = await _context.CategoriaProductos
                .FirstOrDefaultAsync(m => m.IdcategoriaProducto == id);
            if (categoriaProducto == null)
            {
                return NotFound();
            }

            return View(categoriaProducto);
        }

        // POST: CategoriaProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaProducto = await _context.CategoriaProductos.FindAsync(id);
            if (categoriaProducto != null)
            {
                _context.CategoriaProductos.Remove(categoriaProducto);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaProductoExists(int id)
        {
            return _context.CategoriaProductos.Any(e => e.IdcategoriaProducto == id);
        }
    }
}
