using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class StatusEmprestimosController : Controller
    {
        private readonly BibliotecaContext _context;

        public StatusEmprestimosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: StatusEmprestimos
        public async Task<IActionResult> Index()
        {
              return View(await _context.StatusEmprestimo.ToListAsync());
        }

        // GET: StatusEmprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StatusEmprestimo == null)
            {
                return NotFound();
            }

            var statusEmprestimo = await _context.StatusEmprestimo
                .FirstOrDefaultAsync(m => m.StatusEmprestimoID == id);
            if (statusEmprestimo == null)
            {
                return NotFound();
            }

            return View(statusEmprestimo);
        }

        // GET: StatusEmprestimos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StatusEmprestimos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StatusEmprestimoID,Descricao")] StatusEmprestimo statusEmprestimo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(statusEmprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(statusEmprestimo);
        }

        // GET: StatusEmprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StatusEmprestimo == null)
            {
                return NotFound();
            }

            var statusEmprestimo = await _context.StatusEmprestimo.FindAsync(id);
            if (statusEmprestimo == null)
            {
                return NotFound();
            }
            return View(statusEmprestimo);
        }

        // POST: StatusEmprestimos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StatusEmprestimoID,Descricao")] StatusEmprestimo statusEmprestimo)
        {
            if (id != statusEmprestimo.StatusEmprestimoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(statusEmprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusEmprestimoExists(statusEmprestimo.StatusEmprestimoID))
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
            return View(statusEmprestimo);
        }

        // GET: StatusEmprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StatusEmprestimo == null)
            {
                return NotFound();
            }

            var statusEmprestimo = await _context.StatusEmprestimo
                .FirstOrDefaultAsync(m => m.StatusEmprestimoID == id);
            if (statusEmprestimo == null)
            {
                return NotFound();
            }

            return View(statusEmprestimo);
        }

        // POST: StatusEmprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StatusEmprestimo == null)
            {
                return Problem("Entity set 'BibliotecaContext.StatusEmprestimo'  is null.");
            }
            var statusEmprestimo = await _context.StatusEmprestimo.FindAsync(id);
            if (statusEmprestimo != null)
            {
                _context.StatusEmprestimo.Remove(statusEmprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StatusEmprestimoExists(int id)
        {
          return _context.StatusEmprestimo.Any(e => e.StatusEmprestimoID == id);
        }
    }
}
