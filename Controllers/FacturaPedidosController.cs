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
    public class FacturaPedidosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacturaPedidosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FacturaPedidos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FacturaPedidos.Include(f => f.IdpedidoNavigation).Include(f => f.IdproductoNavigation).Include(f => f.IdproveedorNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FacturaPedidos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPedido = await _context.FacturaPedidos
                .Include(f => f.IdpedidoNavigation)
                .Include(f => f.IdproductoNavigation)
                .Include(f => f.IdproveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdfacturaPedido == id);
            if (facturaPedido == null)
            {
                return NotFound();
            }

            return View(facturaPedido);
        }

        // GET: FacturaPedidos/Create
        public IActionResult Create()
        {
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion");
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen");
            ViewData["Idproveedor"] = new SelectList(_context.Proveedors, "Idproveedores", "Direccion");
            return View();
        }

        // POST: FacturaPedidos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdfacturaPedido,Idproveedor,Idproducto,Idpedido,FechaEmision,Iva,Subtotal")] FacturaPedido facturaPedido)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaPedido);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion", facturaPedido.Idpedido);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", facturaPedido.Idproducto);
            ViewData["Idproveedor"] = new SelectList(_context.Proveedors, "Idproveedores", "Direccion", facturaPedido.Idproveedor);
            return View(facturaPedido);
        }

        // GET: FacturaPedidos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPedido = await _context.FacturaPedidos.FindAsync(id);
            if (facturaPedido == null)
            {
                return NotFound();
            }
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion", facturaPedido.Idpedido);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", facturaPedido.Idproducto);
            ViewData["Idproveedor"] = new SelectList(_context.Proveedors, "Idproveedores", "Direccion", facturaPedido.Idproveedor);
            return View(facturaPedido);
        }

        // POST: FacturaPedidos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdfacturaPedido,Idproveedor,Idproducto,Idpedido,FechaEmision,Iva,Subtotal")] FacturaPedido facturaPedido)
        {
            if (id != facturaPedido.IdfacturaPedido)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaPedido);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaPedidoExists(facturaPedido.IdfacturaPedido))
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
            ViewData["Idpedido"] = new SelectList(_context.Pedidos, "Idpedido", "Direccion", facturaPedido.Idpedido);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", facturaPedido.Idproducto);
            ViewData["Idproveedor"] = new SelectList(_context.Proveedors, "Idproveedores", "Direccion", facturaPedido.Idproveedor);
            return View(facturaPedido);
        }

        // GET: FacturaPedidos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaPedido = await _context.FacturaPedidos
                .Include(f => f.IdpedidoNavigation)
                .Include(f => f.IdproductoNavigation)
                .Include(f => f.IdproveedorNavigation)
                .FirstOrDefaultAsync(m => m.IdfacturaPedido == id);
            if (facturaPedido == null)
            {
                return NotFound();
            }

            return View(facturaPedido);
        }

        // POST: FacturaPedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaPedido = await _context.FacturaPedidos.FindAsync(id);
            if (facturaPedido != null)
            {
                _context.FacturaPedidos.Remove(facturaPedido);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaPedidoExists(int id)
        {
            return _context.FacturaPedidos.Any(e => e.IdfacturaPedido == id);
        }
    }
}
