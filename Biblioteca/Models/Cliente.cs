using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Models{
    public class Cliente{

        [Display(Name="Código do Cliente")]
        public int ClienteID {get; set;} 

        [Required]
        [StringLength(60, MinimumLength = 10)]
        [Display(Name="Nome Completo")]
        public string NomeCompleto{get; set;}

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$")]
        [Display(Name="CPF")]
        public string Cpf {get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$")]
        public string Email {get; set;}

        
        
    }
}