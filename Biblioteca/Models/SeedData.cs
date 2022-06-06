using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Biblioteca.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BibliotecaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BibliotecaContext>>()))
            {
                // Look for any movies.
                if (context.Autor.Any())
                {
                    return;   // DB has been seeded
                }else{
                    context.Autor.AddRange(
                        new Autor{
                            AutorID = 1,
                            NomeCompleto = "Paulo de Barros Carvalho",
                            Classificacao = "C331",
                        },
                        new Autor{
                            AutorID = 2,
                            NomeCompleto = "Carlos Roberto Gonçalves",
                            Classificacao = "G635",
                        },
                        new Autor{
                            AutorID = 3,
                            NomeCompleto = "Maria Helena Diniz",
                            Classificacao = "D585",
                        },
                        new Autor{
                            AutorID = 4,
                            NomeCompleto = "Pressman, Roger S.",
                            Classificacao = "P935",
                        }

                    );
                }

                if (context.Assunto.Any())
                {
                    return;   // DB has been seeded
                }else{
                    context.Assunto.AddRange(
                        new Assunto{
                            AssuntoID = 1,
                            Descricao = "Programação de computador, programas e dados",
                            Classificacao = "005.1",
                        },
                        new Assunto{
                            AssuntoID = 2,
                            Descricao = "Direito Civil - Diversas espécies de direitos",
                            Classificacao = "342.1121",
                        },
                        new Assunto{
                            AssuntoID = 3,
                            Descricao = "Direito Tributário",
                            Classificacao = "341.39",
                        }
                    );
                }

                if (context.StatusLivro.Any())
                {
                    return;   // DB has been seeded
                }else{
                    context.StatusLivro.AddRange(
                        new StatusLivro{
                            StatusLivroID = 1,
                            Descricao = "Disponível",
                        },
                        new StatusLivro{
                            StatusLivroID = 2,
                            Descricao = "Emprestado",
                        },
                        new StatusLivro{
                            StatusLivroID = 3,
                            Descricao = "Desaparecido",
                        },
                        new StatusLivro{
                            StatusLivroID = 4,
                            Descricao = "Danificado",
                        },
                        new StatusLivro{
                            StatusLivroID = 5,
                            Descricao = "Reservado",
                        }
                    );
                }

                if (context.StatusEmprestimo.Any())
                {
                    return;   // DB has been seeded
                }else{
                    context.StatusEmprestimo.AddRange(
                        new StatusEmprestimo{
                            StatusEmprestimoID = 1,
                            Descricao = "Confirmado",
                        },
                        new StatusEmprestimo{
                            StatusEmprestimoID = 2,
                            Descricao = "Pendente",
                        },
                        new StatusEmprestimo{
                            StatusEmprestimoID = 3,
                            Descricao = "Cancelado",
                        },
                        new StatusEmprestimo{
                            StatusEmprestimoID = 4,
                            Descricao = "Reservado",
                        },
                        new StatusEmprestimo{
                            StatusEmprestimoID = 5,
                            Descricao = "Finalizado",
                        }
                        
                    );
                }

                if (context.Livro.Any())
                {
                    return;   // DB has been seeded
                }else{
                    context.Livro.AddRange(
                        new Livro{
                            LivroID = 1,
                            Titulo = "Direito Civil Brasileiro - Parte Geral",
                            Descricao = "Data de fechamento: 05.10.2020. A obra Direito Civil Brasileiro, v. 2, de Carlos Roberto Gonçalves, apresenta os principais aspectos e desdobramentos doutrinários e jurisprudenciais sobre as Obrigações no direito civil. O autor trata de temas como: modalidades obrigacionais, obrigação de dar, fazer, não fazer, alternativas, divisíveis, indivisíveis, solidárias, civis, naturais, de execução diferida, de execução continuada, puras, simples, condicionais, modais, liquidas, ilíquidas, principais e acessórias. Além de explorar as transmissões das obrigações, cessão de crédito, assunção de dívida, cessão de contrato, adimplemento e extinção das obrigações. E de forma especifica a análise de pagamento, consignação, sub-rogação, imputação, dação, novação, compensação, confusão, remissão de dívidas, mora, perdas e danos, juros legais, cláusula penal e arras. Obra indicada para alunos de graduação, pós-graduação e profissionais da área.",
                            AnoPublicacao = 2018,
                            Edicao = 17,
                            Editora = "Saraiva",
                            Paginas = 584,
                            AssuntoID = 2,
                            AutorID = 2,
                            StatusLivroID = 1,
                        },
                        new Livro{
                            LivroID = 2,
                            Titulo = "Direito Civil Brasileiro - Teoria Geral das Obrigações",
                            Descricao = "Data de fechamento: 05.10.2020. A obra Direito Civil Brasileiro, v. 2, de Carlos Roberto Gonçalves, apresenta os principais aspectos e desdobramentos doutrinários e jurisprudenciais sobre as Obrigações no direito civil. O autor trata de temas como: modalidades obrigacionais, obrigação de dar, fazer, não fazer, alternativas, divisíveis, indivisíveis, solidárias, civis, naturais, de execução diferida, de execução continuada, puras, simples, condicionais, modais, liquidas, ilíquidas, principais e acessórias. Além de explorar as transmissões das obrigações, cessão de crédito, assunção de dívida, cessão de contrato, adimplemento e extinção das obrigações. E de forma especifica a análise de pagamento, consignação, sub-rogação, imputação, dação, novação, compensação, confusão, remissão de dívidas, mora, perdas e danos, juros legais, cláusula penal e arras. Obra indicada para alunos de graduação, pós-graduação e profissionais da área.",
                            AnoPublicacao = 2019,
                            Edicao = 16,
                            Editora = "Saraiva",
                            Paginas = 436,
                            AssuntoID = 2,
                            AutorID = 2,
                            StatusLivroID = 1,
                        },

                        new Livro{
                            LivroID = 3,
                            Titulo = "Engenharia de Software: Uma Abordagem Profissional",
                            Descricao = "Com mais de três décadas de liderança de mercado, Engenharia de Software chega à sua 8ª edição como o mais abrangente guia sobre essa importante área.Totalmente revisada e reestruturada, esta nova edição foi amplamente atualizada para incluir os novos tópicos da “engenharia do século 21”. Capítulos inéditos abordam a segurança de software e os desafios específicos ao desenvolvimento para aplicativos móveis. Conteúdos novos também foram incluídos em capítulos existentes, e caixas de texto informativas e conteúdos auxiliares foram expandidos, deixando este guia ainda mais prático para uso em sala de aula e em estudos autodidatas.",
                            AnoPublicacao = 2016,
                            Edicao = 8,
                            Editora = "McGraw-Hill",
                            Paginas = 780,
                            AssuntoID = 1,
                            AutorID = 4,
                            StatusLivroID = 1,
                        }
                    );
                }

                if (context.Cliente.Any())
                {
                    return;   // DB has been seeded
                }else{
                    context.Cliente.AddRange(
                        new Cliente{
                            ClienteID = 1,
                            NomeCompleto = "João dos Santos de Oliveira",
                            Cpf = "46895632178",
                            Email = "joao.santos@hotmail.com",
                        },
                        new Cliente{
                            ClienteID = 2,
                            NomeCompleto = "Marcela Regina da Silva",
                            Cpf = "48469789526",
                            Email = "marcela.silva@hotmail.com",
                        },
                        new Cliente{
                            ClienteID = 3,
                            NomeCompleto = "Matheus Santos de Oliveira",
                            Cpf = "47562158926",
                            Email = "matheusoliveira@gmail.com",
                        },
                        new Cliente{
                            ClienteID = 4,
                            NomeCompleto = "Carlos de Oliveira Manzano",
                            Cpf = "48569231478",
                            Email = "carlos_manzano@hotmail.com",
                        }

                    );
                }
                
                context.SaveChanges();
            }
        }
    }
}