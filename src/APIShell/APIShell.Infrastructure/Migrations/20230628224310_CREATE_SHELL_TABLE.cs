using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace APIShell.Infrastructure.Migrations
{
    public partial class CREATE_SHELL_TABLE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_API_SHELL",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(maxLength: 50, nullable: false),
                    Endereco = table.Column<string>(maxLength: 100, nullable: false),
                    Cidade = table.Column<string>(maxLength: 30, nullable: false),
                    Estado = table.Column<string>(maxLength: 30, nullable: false),
                    CEP = table.Column<string>(maxLength: 10, nullable: false),
                    Telefone = table.Column<string>(maxLength: 20, nullable: false),
                    Idade = table.Column<string>(maxLength: 2, nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: false),
                    DataCadastro = table.Column<DateTime>(nullable: false),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    Observacao = table.Column<string>(maxLength: 2147483647, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_API_SHELL", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_API_SHELL");
        }
    }
}
