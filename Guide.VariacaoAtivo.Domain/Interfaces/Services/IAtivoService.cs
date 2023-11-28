using Guide.VariacaoAtivo.Domain.DTOs;
using Guide.VariacaoAtivo.Domain.Models;

namespace Guide.VariacaoAtivo.Domain.Interfaces.Services
{
    public interface IAtivoService
    {
        Task<Result<Ativo>> GetAtivoById(Guid id);
        Task<Result<Ativo>> GetAllAtivos();
        Task<Result<Ativo>> PostAtivo(Ativo ativo);
        Task<Result<Ativo>> GetHistoricalPricesFromYahoo(string ativo);
    }
}
