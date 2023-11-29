namespace Guide.VariacaoAtivo.Domain.Models
{
    public class Ativo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Dia { get; set; }

        public DateTime Data { get; set; }

        public decimal Valor { get; set; }

        public decimal VariacaoDiaAnterior { get; set; }

        public decimal VariacaoPrimeiraData { get; set; }

    }
}
