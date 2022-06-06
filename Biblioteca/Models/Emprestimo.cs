using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Models{
    public class Emprestimo {

        [Display(Name="Código do Empréstimo")]
        public int EmprestimoID {get; set;}


        [Display(Name="Nome do Livro")]
        public int LivroID {get; set;}

        [Display(Name="Nome do Cliente")]
        public int ClienteID {get; set;}

        [Required]
        [Display(Name="Data de Retirada")]
        [DataType(DataType.Date)]
        public DateTime DataRetirada {get; set;}

        [Required]
        [Display(Name="Data de Devolução")]
        [DataType(DataType.Date)]
        public DateTime DataDevolucao {get; set;}
        
        [Display(Name="Situação")]
        public int StatusEmprestimoID {get; set;}



        [Display(Name="Nome do Livro")]
        public virtual Livro Livro {get; set;}


        [Display(Name="Nome do Cliente")]
        public virtual Cliente Cliente {get; set;}
          
        [Display(Name="Situação")]
        public virtual StatusEmprestimo StatusEmprestimo {get; set;}

    }
}