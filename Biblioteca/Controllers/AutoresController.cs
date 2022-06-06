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
    public class AutoresController : Controller
    {
        private readonly BibliotecaContext _context;

        public AutoresController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Autores
        public async Task<IActionResult> Index(string searchString)
        {
             var autores = from a in _context.Autor
             select a;

            if (!String.IsNullOrEmpty(searchString))
                {
                    autores = autores.Where(s => s.NomeCompleto.ToLower().Contains(searchString.ToLower()));
                }

            return View(await autores.ToListAsync());   
            
        }

        // GET: Autores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.AutorID == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);

        }

        // GET: Autores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutorID,NomeCompleto,Classificacao")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            return View(autor);
        }

        // POST: Autores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutorID,NomeCompleto,Classificacao")] Autor autor)
        {
            if (id != autor.AutorID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.AutorID))
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
            return View(autor);
        }

        // GET: Autores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autor == null)
            {
                return NotFound();
            }

            var autor = await _context.Autor
                .FirstOrDefaultAsync(m => m.AutorID == id);
            if (autor == null)
            {
                return NotFound();
            }

            return View(autor);
        }

        // POST: Autores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autor == null)
            {
                return Problem("Entity set 'BibliotecaContext.Autor'  is null.");
            }
            var autor = await _context.Autor.FindAsync(id);
            if (autor != null)
            {
                _context.Autor.Remove(autor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id)
        {
          return _context.Autor.Any(e => e.AutorID == id);
        }
    }
}
