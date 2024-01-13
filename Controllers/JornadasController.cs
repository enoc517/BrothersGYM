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
    public class JornadasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JornadasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Jornadas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Empleados.Include(j => j.IdpuestoNavigation);
            return View("Lista",await applicationDbContext.ToListAsync());
        }

        // GET: Jornadas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadum = await _context.Empleados
                .Include(p => p.IdpuestoNavigation)
                .Include(k => k.Jornada)
                .FirstOrDefaultAsync(m => m.Idempleado == id);
            if (jornadum == null)
            {
                return NotFound();
            }

            return View("Ver",jornadum);
        }

        // GET: Jornadas/Create
        public async Task<IActionResult> Create(int? id)
        {
            var empleado = await _context.Empleados
            .Include(e => e.IdpuestoNavigation)
            .FirstOrDefaultAsync(m => m.Idempleado == id);
            ViewData["EmpleadoId"] = empleado.Idempleado;
            ViewData["Nombre"] = empleado.Nombre + " " + empleado.Apellido;
            ViewData["PagoHora"] = empleado.IdpuestoNavigation.PagHora;
            ViewData["Puesto"] = empleado.IdpuestoNavigation.Nombre;
            return View();
        }


        // POST: Jornadas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idjornada,Idempleado,DiaHoraEntrada,DiaHoraSalida,HorasTrabajadas,SalarioBruto")] Jornadum jornadum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jornadum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido", jornadum.Idempleado);
            return View(jornadum);
        }

        // GET: Jornadas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadum = await _context.Jornada.FindAsync(id);
            if (jornadum == null)
            {
                return NotFound();
            }
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido", jornadum.Idempleado);
            return View(jornadum);
        }

        // POST: Jornadas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idjornada,Idempleado,DiaHoraEntrada,DiaHoraSalida,HorasTrabajadas,SalarioBruto")] Jornadum jornadum)
        {
            if (id != jornadum.Idjornada)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jornadum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JornadumExists(jornadum.Idjornada))
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
            ViewData["Idempleado"] = new SelectList(_context.Empleados, "Idempleado", "Apellido", jornadum.Idempleado);
            return View(jornadum);
        }

        // GET: Jornadas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jornadum = await _context.Jornada
                .Include(j => j.IdempleadoNavigation)
                .FirstOrDefaultAsync(m => m.Idjornada == id);
            if (jornadum == null)
            {
                return NotFound();
            }

            return View(jornadum);
        }

        // POST: Jornadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jornadum = await _context.Jornada.FindAsync(id);
            if (jornadum != null)
            {
                _context.Jornada.Remove(jornadum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JornadumExists(int id)
        {
            return _context.Jornada.Any(e => e.Idjornada == id);
        }
    }
}
