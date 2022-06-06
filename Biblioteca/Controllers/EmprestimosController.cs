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
    public class EmprestimosController : Controller
    {
        private readonly BibliotecaContext _context;

        public EmprestimosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Emprestimos
        public async Task<IActionResult> Index(string searchString)
        {
             var emprestimos = from e in _context.Emprestimo.Include(e => e.Cliente).Include(e => e.Livro).Include(e => e.StatusEmprestimo)
                 select e;

            if(!String.IsNullOrEmpty(searchString))
            {
               emprestimos = emprestimos.Where(
                   s => s.Cliente.NomeCompleto.ToLower().Contains(searchString.ToLower())|| 
                        s.Livro.Titulo.ToLower().Contains(searchString.ToLower()) ||
                        s.StatusEmprestimo.Descricao.ToLower().Contains(searchString.ToLower())
                );
               
            }

            return View(await emprestimos.ToListAsync());   
            
        }

        [HttpPost]
        public string Index(string SearchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + SearchString;
        } 

        // GET: Emprestimos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.Cliente)
                .Include(e => e.Livro)
                .Include(e => e.StatusEmprestimo)
                .FirstOrDefaultAsync(m => m.EmprestimoID == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // GET: Emprestimos/Create
        public IActionResult Create()
        {
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "NomeCompleto");
            ViewData["LivroID"] = new SelectList(_context.Livro, "LivroID", "Titulo");
            ViewData["StatusEmprestimoID"] = new SelectList(_context.StatusEmprestimo, "StatusEmprestimoID", "Descricao");
            return View();
        }

        // POST: Emprestimos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmprestimoID,LivroID,ClienteID,DataRetirada,DataDevolucao,StatusEmprestimoID")] Emprestimo emprestimo)
        {
            if (ModelState.IsValid)
            {
                  
                _context.Add(emprestimo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
                
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "NomeCompleto", emprestimo.ClienteID);
            ViewData["LivroID"] = new SelectList(_context.Livro, "LivroID", "Titulo", emprestimo.LivroID);
            ViewData["StatusEmprestimoID"] = new SelectList(_context.StatusEmprestimo, "StatusEmprestimoID", "Descricao", emprestimo.StatusEmprestimoID);
            return View(emprestimo);
        }

        // GET: Emprestimos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo == null)
            {
                return NotFound();
            }
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "NomeCompleto", emprestimo.ClienteID);
            ViewData["LivroID"] = new SelectList(_context.Livro, "LivroID", "Titulo", emprestimo.LivroID);
            ViewData["StatusEmprestimoID"] = new SelectList(_context.StatusEmprestimo, "StatusEmprestimoID", "Descricao", emprestimo.StatusEmprestimoID);
            return View(emprestimo);
        }

        // POST: Emprestimos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmprestimoID,LivroID,ClienteID,DataRetirada,DataDevolucao,StatusEmprestimoID")] Emprestimo emprestimo)
        {
            if (id != emprestimo.EmprestimoID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emprestimo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmprestimoExists(emprestimo.EmprestimoID))
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
            ViewData["ClienteID"] = new SelectList(_context.Cliente, "ClienteID", "NomeCompleto", emprestimo.ClienteID);
            ViewData["LivroID"] = new SelectList(_context.Livro, "LivroID", "Titulo", emprestimo.LivroID);
            ViewData["StatusEmprestimoID"] = new SelectList(_context.StatusEmprestimo, "StatusEmprestimoID", "Descricao", emprestimo.StatusEmprestimoID);
            return View(emprestimo);
        }

        // GET: Emprestimos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Emprestimo == null)
            {
                return NotFound();
            }

            var emprestimo = await _context.Emprestimo
                .Include(e => e.Cliente)
                .Include(e => e.Livro)
                .Include(e => e.StatusEmprestimo)
                .FirstOrDefaultAsync(m => m.EmprestimoID == id);
            if (emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        // POST: Emprestimos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Emprestimo == null)
            {
                return Problem("Entity set 'BibliotecaContext.Emprestimo'  is null.");
            }
            var emprestimo = await _context.Emprestimo.FindAsync(id);
            if (emprestimo != null)
            {
                _context.Emprestimo.Remove(emprestimo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmprestimoExists(int id)
        {
          return _context.Emprestimo.Any(e => e.EmprestimoID == id);
        }
    }
}
