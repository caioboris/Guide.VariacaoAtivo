using Guide.VariacaoAtivo.Domain.DTOs;
using Guide.VariacaoAtivo.Domain.Interfaces.Services;
using Guide.VariacaoAtivo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Guide.VariacaoAtivo.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AtivoController : ControllerBase
    {
        private readonly IAtivoService _ativoService;

        public AtivoController(IAtivoService ativoService)
        {
            _ativoService = ativoService;
        }

        [HttpGet("{ativo}")]
        public async Task<Result<Ativo>> GetStockHistoricalPrices(string ativo)
        {
            var result = await _ativoService.GetStockHistoricalPrices(ativo);

            return result;
        }
    }
}
