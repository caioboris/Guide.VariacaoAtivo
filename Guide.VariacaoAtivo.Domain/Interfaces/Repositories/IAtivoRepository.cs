using Guide.VariacaoAtivo.Domain.Models;

namespace Guide.VariacaoAtivo.Domain.Interfaces.Repositories
{
    public interface IAtivoRepository
    {
        List<Ativo> GetAllAtivos();
        void PostAtivo(Ativo ativo);
        void ClearTable();
    }
}
