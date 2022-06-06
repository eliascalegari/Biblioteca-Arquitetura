using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Models{
    public class Autor{

        [Display(Name="Código do Autor")]
        public int AutorID {get; set; }

        [Required]
        [StringLength(60, MinimumLength = 10)]
        public string NomeCompleto {get; set; }

        [Required]
        [Display(Name="Classificação")]
        public string Classificacao {get; set;}

        public virtual ICollection<Livro> Livros {get; set;}

    }
}