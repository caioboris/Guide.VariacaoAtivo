using System.Net;

namespace Guide.VariacaoAtivo.Domain.DTOs
{
    public class Result<T>
    {
        public List<T> Data { get; set; } = new List<T>();

        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;

    }
}
