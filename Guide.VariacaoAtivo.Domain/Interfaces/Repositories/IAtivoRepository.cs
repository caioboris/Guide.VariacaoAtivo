using Guide.VariacaoAtivo.Domain.Models;

namespace Guide.VariacaoAtivo.Domain.Interfaces.Repositories
{
    public interface IAtivoRepository
    {
        Task<Ativo> GetAtivoById(Guid id);
        Task<List<Ativo>> GetAllAtivos();
        void PutAtivo(Ativo ativo);
        void PostAtivo(Ativo ativo);
        void DeleteAtivo(Guid id);
    }
}
