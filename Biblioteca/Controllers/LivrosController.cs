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
    public class LivrosController : Controller
    {
        private readonly BibliotecaContext _context;

        public LivrosController(BibliotecaContext context)
        {
            _context = context;
        }

        // GET: Livros
        public async Task<IActionResult> Index(string searchString)
        {
             var livros = from l in _context.Livro.Include(l => l.Assunto).Include(l => l.Autor).Include(l => l.StatusLivro) select l;

            if(!String.IsNullOrEmpty(searchString))
            {
               livros = livros.Where(
                   l => l.Titulo.ToLower().Contains(searchString.ToLower())|| 
                        l.Assunto.Descricao.ToLower().Contains(searchString.ToLower()) ||
                        l.Autor.NomeCompleto.ToLower().Contains(searchString.ToLower()) ||
                        l.Descricao.ToLower().Contains(searchString.ToLower()) ||
                        l.StatusLivro.Descricao.ToLower().Contains(searchString.ToLower())

                );
               
            }

            return View(await livros.ToListAsync());   
            
        }

        [HttpPost]
        public string Index(string SearchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + SearchString;
        }  


        // GET: Livros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Assunto)
                .Include(l => l.Autor)
                .Include(l => l.StatusLivro)
                .FirstOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // GET: Livros/Create
        public IActionResult Create()
        {
            ViewData["AssuntoID"] = new SelectList(_context.Assunto, "AssuntoID", "Descricao");
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "NomeCompleto");
            ViewData["StatusLivroID"] = new SelectList(_context.StatusLivro, "StatusLivroID", "Descricao");
            return View();
        }

        // POST: Livros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LivroID,Titulo,Descricao,AnoPublicacao,Edicao,Editora,Paginas,AssuntoID,AutorID,StatusLivroID")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(livro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AssuntoID"] = new SelectList(_context.Assunto, "AssuntoID", "Descricao", livro.AssuntoID);
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "NomeCompleto", livro.AutorID);
            ViewData["StatusLivroID"] = new SelectList(_context.StatusLivro, "StatusLivroID", "Descricao", livro.StatusLivroID);
            return View(livro);
        }

        // GET: Livros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro.FindAsync(id);
            if (livro == null)
            {
                return NotFound();
            }
            ViewData["AssuntoID"] = new SelectList(_context.Assunto, "AssuntoID", "Descricao", livro.AssuntoID);
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "NomeCompleto", livro.AutorID);
            ViewData["StatusLivroID"] = new SelectList(_context.StatusLivro, "StatusLivroID", "Descricao", livro.StatusLivroID);
            return View(livro);
        }

        // POST: Livros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LivroID,Titulo,Descricao,AnoPublicacao,Edicao,Editora,Paginas,AssuntoID,AutorID,StatusLivroID")] Livro livro)
        {
            if (id != livro.LivroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(livro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.LivroID))
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
            ViewData["AssuntoID"] = new SelectList(_context.Assunto, "AssuntoID", "Descricao", livro.AssuntoID);
            ViewData["AutorID"] = new SelectList(_context.Autor, "AutorID", "NomeCompleto", livro.AutorID);
            ViewData["StatusLivroID"] = new SelectList(_context.StatusLivro, "StatusLivroID", "Descricao", livro.StatusLivroID);
            return View(livro);
        }

        // GET: Livros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Livro == null)
            {
                return NotFound();
            }

            var livro = await _context.Livro
                .Include(l => l.Assunto)
                .Include(l => l.Autor)
                .Include(l => l.StatusLivro)
                .FirstOrDefaultAsync(m => m.LivroID == id);
            if (livro == null)
            {
                return NotFound();
            }

            return View(livro);
        }

        // POST: Livros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Livro == null)
            {
                return Problem("Entity set 'BibliotecaContext.Livro'  is null.");
            }
            var livro = await _context.Livro.FindAsync(id);
            if (livro != null)
            {
                _context.Livro.Remove(livro);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id)
        {
          return _context.Livro.Any(e => e.LivroID == id);
        }
    }
}
