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
    public class PaqueteSesionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PaqueteSesionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PaqueteSesiones
        public async Task<IActionResult> Index()
        {
            return View(await _context.PaquteSesiones.ToListAsync());
        }

        // GET: PaqueteSesiones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquteSesione = await _context.PaquteSesiones
                .FirstOrDefaultAsync(m => m.PaqueteSesioensId == id);
            if (paquteSesione == null)
            {
                return NotFound();
            }

            return View(paquteSesione);
        }

        // GET: PaqueteSesiones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaqueteSesiones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PaqueteSesioensId,Nombre,Cantidad")] PaquteSesione paquteSesione)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paquteSesione);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paquteSesione);
        }

        // GET: PaqueteSesiones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquteSesione = await _context.PaquteSesiones.FindAsync(id);
            if (paquteSesione == null)
            {
                return NotFound();
            }
            return View(paquteSesione);
        }

        // POST: PaqueteSesiones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PaqueteSesioensId,Nombre,Cantidad")] PaquteSesione paquteSesione)
        {
            if (id != paquteSesione.PaqueteSesioensId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paquteSesione);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaquteSesioneExists(paquteSesione.PaqueteSesioensId))
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
            return View(paquteSesione);
        }

        // GET: PaqueteSesiones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paquteSesione = await _context.PaquteSesiones
                .FirstOrDefaultAsync(m => m.PaqueteSesioensId == id);
            if (paquteSesione == null)
            {
                return NotFound();
            }

            return View(paquteSesione);
        }

        // POST: PaqueteSesiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paquteSesione = await _context.PaquteSesiones.FindAsync(id);
            if (paquteSesione != null)
            {
                _context.PaquteSesiones.Remove(paquteSesione);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaquteSesioneExists(int id)
        {
            return _context.PaquteSesiones.Any(e => e.PaqueteSesioensId == id);
        }
    }
}
