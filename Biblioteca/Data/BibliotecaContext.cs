using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Models;


    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext (DbContextOptions<BibliotecaContext> options)
            : base(options)
        {
        }

        public DbSet<Biblioteca.Models.Assunto>? Assunto { get; set; }

        public DbSet<Biblioteca.Models.Autor>? Autor { get; set; }

        public DbSet<Biblioteca.Models.StatusLivro>? StatusLivro { get; set; }

        public DbSet<Biblioteca.Models.StatusEmprestimo>? StatusEmprestimo { get; set; }

        public DbSet<Biblioteca.Models.Livro>? Livro { get; set; }

        public DbSet<Biblioteca.Models.Cliente>? Cliente { get; set; }

        public DbSet<Biblioteca.Models.Emprestimo>? Emprestimo { get; set; }
    }
