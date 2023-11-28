using Guide.VariacaoAtivo.Domain.Models;

namespace Guide.VariacaoAtivo.Domain.Interfaces.Repositories
{
    public interface IVariacaoAtivoRepository
    {
        Task<Ativo> GetVariacaoAtivoById();
        Task<List<Ativo>> GetAllAtivos();
        Task<Ativo> PutAtivo(Ativo ativo);
        Task<Ativo> PostAtivo(Ativo ativo);
        Task<Ativo> DeleteAtivo(Ativo ativo);
    }
}
