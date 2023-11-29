using Guide.VariacaoAtivo.Domain.DTOs;
using Guide.VariacaoAtivo.Domain.Models;

namespace Guide.VariacaoAtivo.Domain.Interfaces.Services
{
    public interface IAtivoService
    {
        Task<Result<Ativo>> GetStockHistoricalPrices(string ativo);
    }
}
