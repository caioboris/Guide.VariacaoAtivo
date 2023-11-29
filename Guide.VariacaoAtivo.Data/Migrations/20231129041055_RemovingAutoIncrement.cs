using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Guide.VariacaoAtivo.Data.Migrations
{
    public partial class RemovingAutoIncrement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("TB_VARIACAO_ATIVOS");

            migrationBuilder.CreateTable(
                name: "TB_VARIACAO_ATIVOS",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Dia = table.Column<int>(type: "int", nullable: false),
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
            migrationBuilder.AlterColumn<int>(
                name: "Dia",
                table: "TB_VARIACAO_ATIVOS",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
