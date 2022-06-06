using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models{
    public class StatusLivro{
        
        [Display(Name="Código")]
        public int StatusLivroID {get; set;}

        [Required]
        [Display(Name="Descrição")]
        public string Descricao {get; set;}

        public virtual ICollection<Livro> Livros {get; set;}
    }
}