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
    public class ClienteSesionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteSesionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClienteSesiones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClienteSesiones.Include(c => c.IdsesionesNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClienteSesiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteSesione = await _context.ClienteSesiones
                .Include(c => c.IdsesionesNavigation)
                .FirstOrDefaultAsync(m => m.IdclienteSesiones == id);
            if (clienteSesione == null)
            {
                return NotFound();
            }

            return View(clienteSesione);
        }

        // GET: ClienteSesiones/Create
        public IActionResult Create()
        {
            ViewData["Idsesiones"] = new SelectList(_context.SesionesRayosUvs, "Idsesiones", "Descripcion");
            return View();
        }

        // POST: ClienteSesiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdclienteSesiones,Idsesiones,FechaCita,Estado")] ClienteSesione clienteSesione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteSesione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idsesiones"] = new SelectList(_context.SesionesRayosUvs, "Idsesiones", "Descripcion", clienteSesione.Idsesiones);
            return View(clienteSesione);
        }

        // GET: ClienteSesiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteSesione = await _context.ClienteSesiones.FindAsync(id);
            if (clienteSesione == null)
            {
                return NotFound();
            }
            ViewData["Idsesiones"] = new SelectList(_context.SesionesRayosUvs, "Idsesiones", "Descripcion", clienteSesione.Idsesiones);
            return View(clienteSesione);
        }

        // POST: ClienteSesiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdclienteSesiones,Idsesiones,FechaCita,Estado")] ClienteSesione clienteSesione)
        {
            if (id != clienteSesione.IdclienteSesiones)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteSesione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteSesioneExists(clienteSesione.IdclienteSesiones))
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
            ViewData["Idsesiones"] = new SelectList(_context.SesionesRayosUvs, "Idsesiones", "Descripcion", clienteSesione.Idsesiones);
            return View(clienteSesione);
        }

        // GET: ClienteSesiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteSesione = await _context.ClienteSesiones
                .Include(c => c.IdsesionesNavigation)
                .FirstOrDefaultAsync(m => m.IdclienteSesiones == id);
            if (clienteSesione == null)
            {
                return NotFound();
            }

            return View(clienteSesione);
        }

        // POST: ClienteSesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteSesione = await _context.ClienteSesiones.FindAsync(id);
            if (clienteSesione != null)
            {
                _context.ClienteSesiones.Remove(clienteSesione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteSesioneExists(int id)
        {
            return _context.ClienteSesiones.Any(e => e.IdclienteSesiones == id);
        }
    }
}
