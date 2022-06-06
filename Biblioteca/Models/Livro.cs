using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Models{
    public class Livro{
        [Display(Name="Código do Livro")]
        public int LivroID {get; set;}

        [Required]
        [Display(Name="Título")]
        public string Titulo {get; set;}

        [Display(Name="Descrição")]
        public string Descricao {get; set; }

        [Required]
        [Range(1900, 2022)]
        [Display(Name="Ano de Publicação")]
        public int AnoPublicacao {get; set;}

        [Range(1, 100)]
        [Required]
        [Display(Name="Edição")]
        public int Edicao {get; set;}

        [Required]
        public string Editora {get; set; }

        [Range(1, 10000)]
        [Required]
        [Display(Name="Páginas")]
        public int Paginas {get; set; }

        [Display(Name="Assunto")]
        public int AssuntoID {get; set;}

        [Display(Name="Autor")]
        public int AutorID {get; set;}

        [Display(Name="Situação do Livro")]
        public int StatusLivroID {get; set;}

        public virtual Assunto Assunto {get; set;}
        public virtual Autor Autor {get; set;}

        [Display(Name="Situação do Livro")]
        public virtual StatusLivro StatusLivro {get; set;}

     
    }
}