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
    public class AssuntosController : Controller
    {
        private readonly BibliotecaContext _context;

        public AssuntosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Assuntos
        public async Task<IActionResult> Index(string searchString)
        {
             var assuntos = from c in _context.Assunto
                select c;

            if(!String.IsNullOrEmpty(searchString))
            {
               assuntos = assuntos.Where(
                   s => s.Descricao.ToLower().Contains(searchString.ToLower())|| 
                        s.Classificacao.ToLower().Contains(searchString.ToLower())
                );
               
            }

            return View(await assuntos.ToListAsync());   
            
        }

        [HttpPost]
        public string Index(string SearchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + SearchString;
        } 
        // GET: Assuntos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assunto == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assunto
                .FirstOrDefaultAsync(m => m.AssuntoID == id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // GET: Assuntos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assuntos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AssuntoID,Descricao,Classificacao")] Assunto assunto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assunto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assunto);
        }

        // GET: Assuntos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assunto == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assunto.FindAsync(id);
            if (assunto == null)
            {
                return NotFound();
            }
            return View(assunto);
        }

        // POST: Assuntos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AssuntoID,Descricao,Classificacao")] Assunto assunto)
        {
            if (id != assunto.AssuntoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assunto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssuntoExists(assunto.AssuntoID))
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
            return View(assunto);
        }

        // GET: Assuntos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assunto == null)
            {
                return NotFound();
            }

            var assunto = await _context.Assunto
                .FirstOrDefaultAsync(m => m.AssuntoID == id);
            if (assunto == null)
            {
                return NotFound();
            }

            return View(assunto);
        }

        // POST: Assuntos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assunto == null)
            {
                return Problem("Entity set 'BibliotecaContext.Assunto'  is null.");
            }
            var assunto = await _context.Assunto.FindAsync(id);
            if (assunto != null)
            {
                _context.Assunto.Remove(assunto);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssuntoExists(int id)
        {
          return _context.Assunto.Any(e => e.AssuntoID == id);
        }
    }
}
