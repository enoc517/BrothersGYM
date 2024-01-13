﻿using System;
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
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ventas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Venta.Include(v => v.IdclienteNavigation).Include(v => v.IdempleadoNavigation).Include(v => v.IdproductoNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ventas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdclienteNavigation)
                .Include(v => v.IdempleadoNavigation)
                .Include(v => v.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // GET: Ventas/Create
        public IActionResult Create()
        {
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido");
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido");
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen");
            return View();
        }

        // POST: Ventas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idventa,Idempleado,Idproducto,Idcliente,Cantidad,Pago")] Ventum ventum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido", ventum.Idcliente);
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido", ventum.Idempleado);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", ventum.Idproducto);
            return View(ventum);
        }

        // GET: Ventas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta.FindAsync(id);
            if (ventum == null)
            {
                return NotFound();
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido", ventum.Idcliente);
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido", ventum.Idempleado);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", ventum.Idproducto);
            return View(ventum);
        }

        // POST: Ventas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idventa,Idempleado,Idproducto,Idcliente,Cantidad,Pago")] Ventum ventum)
        {
            if (id != ventum.Idventa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentumExists(ventum.Idventa))
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
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido", ventum.Idcliente);
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido", ventum.Idempleado);
            ViewData["Idproducto"] = new SelectList(_context.Productos, "Idproducto", "Imagen", ventum.Idproducto);
            return View(ventum);
        }

        // GET: Ventas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventum = await _context.Venta
                .Include(v => v.IdclienteNavigation)
                .Include(v => v.IdempleadoNavigation)
                .Include(v => v.IdproductoNavigation)
                .FirstOrDefaultAsync(m => m.Idventa == id);
            if (ventum == null)
            {
                return NotFound();
            }

            return View(ventum);
        }

        // POST: Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventum = await _context.Venta.FindAsync(id);
            if (ventum != null)
            {
                _context.Venta.Remove(ventum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentumExists(int id)
        {
            return _context.Venta.Any(e => e.Idventa == id);
        }
    }
}
