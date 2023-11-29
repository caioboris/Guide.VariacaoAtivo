using Guide.VariacaoAtivo.Domain.DTOs;
using Guide.VariacaoAtivo.Domain.Interfaces.Repositories;
using Guide.VariacaoAtivo.Domain.Interfaces.Services;
using Guide.VariacaoAtivo.Domain.Models;
using Newtonsoft.Json;

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

        public async Task<Result<Ativo>> GetStockHistoricalPrices(string ativo)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://query2.finance.yahoo.com/v8/finance/chart/{Uri.EscapeDataString(ativo)}?interval=1d&range=1mo");
                var ativos = new List<Ativo>();

                if(response.IsSuccessStatusCode)
                {
                    _ativoRepository.ClearTable();
                    var contentString = await response.Content.ReadAsStringAsync();
                    var contentObject = JsonConvert.DeserializeObject<RootObject>(contentString);
                    
                    if (contentObject != null)
                    {
                        var timestamps = contentObject.Chart.Result.First().Timestamp;
                        var openPrice = contentObject.Chart.Result.First().Indicators.Quote.First().Open;

                        for(int i = 0; i < timestamps.Length - 1; i++)
                        {
                            //Formula de calculo de variacao percentual ->  ((valor novo - valor antigo) / valor antigo) * 100
                            var price = openPrice[i];
                            var previousDayVariation = i <= 0 ? 0 : (price - openPrice[i - 1]) / price * 100;
                            var firstDayVariation = (price - openPrice[0]) / openPrice[0] * 100;

                            var stock = new Ativo
                            {
                                Data = DateTimeOffset.FromUnixTimeSeconds(timestamps[i]).Date,
                                Dia = i + 1,
                                Valor = Math.Round(price, 3),
                                VariacaoDiaAnterior = Math.Round(previousDayVariation,6),
                                VariacaoPrimeiraData = Math.Round(firstDayVariation, 6),
                            };

                            _ativoRepository.PostAtivo(stock);
                        }

                    }
                    
                    ativos = _ativoRepository.GetAllAtivos();

                }

                return new Result<Ativo> { Data = _ativoRepository.GetAllAtivos(), StatusCode = System.Net.HttpStatusCode.OK, Success = true };
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
