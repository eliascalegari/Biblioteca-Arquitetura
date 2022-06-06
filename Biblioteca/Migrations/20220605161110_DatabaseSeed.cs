using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Biblioteca.Migrations
{
    public partial class DatabaseSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assunto",
                columns: table => new
                {
                    AssuntoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assunto", x => x.AssuntoID);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    Classificacao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorID);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeCompleto = table.Column<string>(type: "TEXT", nullable: true),
                    Cpf = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ClienteID);
                });

            migrationBuilder.CreateTable(
                name: "StatusEmprestimo",
                columns: table => new
                {
                    StatusEmprestimoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusEmprestimo", x => x.StatusEmprestimoID);
                });

            migrationBuilder.CreateTable(
                name: "StatusLivro",
                columns: table => new
                {
                    StatusLivroID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusLivro", x => x.StatusLivroID);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    LivroID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Titulo = table.Column<string>(type: "TEXT", nullable: true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    AnoPublicacao = table.Column<int>(type: "INTEGER", nullable: false),
                    Edicao = table.Column<int>(type: "INTEGER", nullable: false),
                    Editora = table.Column<string>(type: "TEXT", nullable: true),
                    Paginas = table.Column<int>(type: "INTEGER", nullable: false),
                    AssuntoID = table.Column<int>(type: "INTEGER", nullable: false),
                    AutorID = table.Column<int>(type: "INTEGER", nullable: false),
                    StatusLivroID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.LivroID);
                    table.ForeignKey(
                        name: "FK_Livro_Assunto_AssuntoID",
                        column: x => x.AssuntoID,
                        principalTable: "Assunto",
                        principalColumn: "AssuntoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "AutorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Livro_StatusLivro_StatusLivroID",
                        column: x => x.StatusLivroID,
                        principalTable: "StatusLivro",
                        principalColumn: "StatusLivroID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    EmprestimoID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LivroID = table.Column<int>(type: "INTEGER", nullable: false),
                    ClienteID = table.Column<int>(type: "INTEGER", nullable: false),
                    DataRetirada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataDevolucao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StatusEmprestimoID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.EmprestimoID);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Cliente_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Cliente",
                        principalColumn: "ClienteID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Livro_LivroID",
                        column: x => x.LivroID,
                        principalTable: "Livro",
                        principalColumn: "LivroID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Emprestimo_StatusEmprestimo_StatusEmprestimoID",
                        column: x => x.StatusEmprestimoID,
                        principalTable: "StatusEmprestimo",
                        principalColumn: "StatusEmprestimoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_ClienteID",
                table: "Emprestimo",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_LivroID",
                table: "Emprestimo",
                column: "LivroID");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_StatusEmprestimoID",
                table: "Emprestimo",
                column: "StatusEmprestimoID");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AssuntoID",
                table: "Livro",
                column: "AssuntoID");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_AutorID",
                table: "Livro",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_StatusLivroID",
                table: "Livro",
                column: "StatusLivroID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "StatusEmprestimo");

            migrationBuilder.DropTable(
                name: "Assunto");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "StatusLivro");
        }
    }
}
