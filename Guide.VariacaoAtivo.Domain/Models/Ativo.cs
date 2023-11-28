namespace Guide.VariacaoAtivo.Domain.Models
{
    public class Ativo
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public int Dia { get; set; }

        public DateTime Data { get; set; }

        public double Valor { get; set; }

        public double VariacaoDiaAnterior { get; set; }

        public double VariacaoPrimeiraData { get; set; }

    }
}
