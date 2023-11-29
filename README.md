# Guide.VariacaoAtivo

Esse é meu projeto de uma API que se integra ao sistema Yahoo Finance e obtém o resultado da variação do ativo durante os últimos 30 pregões, como pede o desafio:  https://github.com/guideti/variacao-ativo

Para desenvolver esse projeto, utilizei uma arquitetura em 3 camadas:
  - Domain: Responsável apenas por manter as regras e domínios da aplicação;
  - Data: Camada de comunicação com o Banco de Dados, apenas essa camada tem a responsabilidade de realizar operações com o banco, utilizando o ORM EntityFramework;
  - Application: Camada de aplicação, que agrupa a controller, a service e demais atribuições que cabem a uma camada mais alta da aplicação como manipulação de exceções e tratamento de dados

O Esquema do banco de dados foi definido no arquivo inicial de migração:
```c#
  public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DropTable(
                name: "TB_VARIACAO_ATIVOS");
        }
    }
```
  Para acessar o banco, utilizei o campo "DefaultConnection" no appsettings.Development.json da camada de aplicação, é necessário para ao rodar os comandos de criação de migração e tabela do entityframework, adicionar esse arquivo para o projeto Data.
  Os comandos do ef core são: 
    dotnet ef migrations add NomeDaMigracao
    dotnet ef database update NomeDaAtualizacao

  A rota para chamada da api definida é a {baseurl}/Ativo/{ativo}
  Sendo a base url a url do servidor onde a aplicação está rodando e o "ativo" o símbolo do ativo na bolsa ex: PETR4.SA, AAPL, PYPL

  O Fluxo definido para que as informações não se misturem, é de sempre que for executado essa rota, inicialmente ocorre uma limpeza na tabela, que é atualizada com os novos valores retornados.
  Uma sugestão de melhoria, seria implementar uma nova tabela e relacionar o ativo recebido na request com o dado armazenado.

    
