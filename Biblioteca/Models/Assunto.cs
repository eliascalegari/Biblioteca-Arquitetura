using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Models{
    public class Assunto {

        [Display(Name="Código do Assunto")]
        public int AssuntoID {get; set;}
        
        [Required]
        [StringLength(60, MinimumLength = 5)]
        [Display(Name="Descrição")]
        public string Descricao {get; set;}

        [Required]
        [Display(Name="Classificação")]
        public string Classificacao {get; set;}

        public virtual ICollection<Livro> Livros {get; set;}

    }
}