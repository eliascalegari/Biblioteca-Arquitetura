using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Models{
    public class StatusEmprestimo{

        [Display(Name="Código")]
        public int StatusEmprestimoID {get; set;}

        [Required]
        [Display(Name="Descrição")]
        public string Descricao {get; set;}

        public virtual ICollection<Emprestimo> Emprestimos {get; set;}
    }
}