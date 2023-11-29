using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guide.VariacaoAtivo.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_VARIACAO_ATIVOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Valor = table.Column<decimal>(type: "DECIMAL(6,3)", nullable: false),
                    VariacaoDiaAnterior = table.Column<decimal>(type: "DECIMAL(8,6)", nullable: false),
                    VariacaoPrimeiraData = table.Column<decimal>(type: "DECIMAL(8,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VARIACAO_ATIVOS", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VARIACAO_ATIVOS");
        }
    }
}
