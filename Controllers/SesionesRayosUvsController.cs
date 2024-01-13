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
    public class SesionesRayosUvsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SesionesRayosUvsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SesionesRayosUvs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.SesionesRayosUvs.Include(s => s.IdclienteNavigation).Include(s => s.PaqueteSesiones);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: SesionesRayosUvs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionesRayosUv = await _context.SesionesRayosUvs
                .Include(s => s.IdclienteNavigation)
                .Include(s => s.PaqueteSesiones)
                .FirstOrDefaultAsync(m => m.Idsesiones == id);
            if (sesionesRayosUv == null)
            {
                return NotFound();
            }

            return View(sesionesRayosUv);
        }

        // GET: SesionesRayosUvs/Create
        public IActionResult Create()
        {
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido");
            ViewData["PaqueteSesionesId"] = new SelectList(_context.PaquteSesiones, "PaqueteSesioensId", "PaqueteSesioensId");
            return View();
        }

        // POST: SesionesRayosUvs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idsesiones,Descripcion,Idcliente,PaqueteSesionesId")] SesionesRayosUv sesionesRayosUv)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sesionesRayosUv);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido", sesionesRayosUv.Idcliente);
            ViewData["PaqueteSesionesId"] = new SelectList(_context.PaquteSesiones, "PaqueteSesioensId", "PaqueteSesioensId", sesionesRayosUv.PaqueteSesionesId);
            return View(sesionesRayosUv);
        }

        // GET: SesionesRayosUvs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionesRayosUv = await _context.SesionesRayosUvs.FindAsync(id);
            if (sesionesRayosUv == null)
            {
                return NotFound();
            }
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido", sesionesRayosUv.Idcliente);
            ViewData["PaqueteSesionesId"] = new SelectList(_context.PaquteSesiones, "PaqueteSesioensId", "PaqueteSesioensId", sesionesRayosUv.PaqueteSesionesId);
            return View(sesionesRayosUv);
        }

        // POST: SesionesRayosUvs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idsesiones,Descripcion,Idcliente,PaqueteSesionesId")] SesionesRayosUv sesionesRayosUv)
        {
            if (id != sesionesRayosUv.Idsesiones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sesionesRayosUv);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SesionesRayosUvExists(sesionesRayosUv.Idsesiones))
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
            ViewData["Idcliente"] = new SelectList(_context.Clientes, "Idcliente", "Apellido", sesionesRayosUv.Idcliente);
            ViewData["PaqueteSesionesId"] = new SelectList(_context.PaquteSesiones, "PaqueteSesioensId", "PaqueteSesioensId", sesionesRayosUv.PaqueteSesionesId);
            return View(sesionesRayosUv);
        }

        // GET: SesionesRayosUvs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sesionesRayosUv = await _context.SesionesRayosUvs
                .Include(s => s.IdclienteNavigation)
                .Include(s => s.PaqueteSesiones)
                .FirstOrDefaultAsync(m => m.Idsesiones == id);
            if (sesionesRayosUv == null)
            {
                return NotFound();
            }

            return View(sesionesRayosUv);
        }

        // POST: SesionesRayosUvs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sesionesRayosUv = await _context.SesionesRayosUvs.FindAsync(id);
            if (sesionesRayosUv != null)
            {
                _context.SesionesRayosUvs.Remove(sesionesRayosUv);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SesionesRayosUvExists(int id)
        {
            return _context.SesionesRayosUvs.Any(e => e.Idsesiones == id);
        }
    }
}
