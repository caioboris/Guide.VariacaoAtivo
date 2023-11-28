using Guide.VariacaoAtivo.Domain.DTOs;
using Guide.VariacaoAtivo.Domain.Interfaces.Repositories;
using Guide.VariacaoAtivo.Domain.Interfaces.Services;
using Guide.VariacaoAtivo.Domain.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Guide.VariacaoAtivo.Application.Services
{
    public class AtivoService : IAtivoService
    {
        private readonly IAtivoRepository _ativoRepository;
        private readonly HttpClient _httpClient;

        public AtivoService(IAtivoRepository ativoRepository)
        {
            _ativoRepository = ativoRepository;
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(30)
            };
        }

        public Task<Result<Ativo>> GetAllAtivos()
        {
            throw new NotImplementedException();
        }

        public Task<Result<Ativo>> GetAtivoById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Result<Ativo>> GetHistoricalPricesFromYahoo(string ativo)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://query2.finance.yahoo.com/v8/finance/chart/{Uri.EscapeDataString(ativo)}?interval=1d&range=1mo");

                if(response.IsSuccessStatusCode)
                {
                    var contentString = await response.Content.ReadAsStringAsync();
                    var contentObject = JsonConvert.DeserializeObject<JObject>(contentString);

                }

                return new Result<Ativo> { };
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Task<Result<Ativo>> PostAtivo(Ativo ativo)
        {
            throw new NotImplementedException();
        }
    }
}
