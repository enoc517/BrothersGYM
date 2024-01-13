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
    public class DetallePedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DetallePedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DetallePedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.DetallePedidos.Include(d => d.IdpedidoNavigation).Include(d => d.IdproductoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: DetallePedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos
                .Include(d => d.IdpedidoNavigation)
                .Include(d => d.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.IddetalleProducto == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // GET: DetallePedidos/Create
        public IActionResult Create()
        {
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion");
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen");
            return View();
        }

        // POST: DetallePedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IddetalleProducto,Idpedido,Idproducto,PrecioUnidad,Cantidad,Descuento")] DetallePedido detallePedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(detallePedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion", detallePedido.Idpedido);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", detallePedido.Idproducto);
            return View(detallePedido);
        }

        // GET: DetallePedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido == null)
            {
                return NotFound();
            }
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion", detallePedido.Idpedido);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", detallePedido.Idproducto);
            return View(detallePedido);
        }

        // POST: DetallePedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IddetalleProducto,Idpedido,Idproducto,PrecioUnidad,Cantidad,Descuento")] DetallePedido detallePedido)
        {
            if (id != detallePedido.IddetalleProducto)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(detallePedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DetallePedidoExists(detallePedido.IddetalleProducto))
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
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion", detallePedido.Idpedido);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", detallePedido.Idproducto);
            return View(detallePedido);
        }

        // GET: DetallePedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var detallePedido = await _context.DetallePedidos
                .Include(d => d.IdpedidoNavigation)
                .Include(d => d.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.IddetalleProducto == id);
            if (detallePedido == null)
            {
                return NotFound();
            }

            return View(detallePedido);
        }

        // POST: DetallePedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var detallePedido = await _context.DetallePedidos.FindAsync(id);
            if (detallePedido != null)
            {
                _context.DetallePedidos.Remove(detallePedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DetallePedidoExists(int id)
        {
            return _context.DetallePedidos.Any(e => e.IddetalleProducto == id);
        }
    }
}
