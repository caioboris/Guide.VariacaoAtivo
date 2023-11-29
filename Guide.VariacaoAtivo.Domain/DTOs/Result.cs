using System.Net;

namespace Guide.VariacaoAtivo.Domain.DTOs
{
    public class Result<T>
    {

        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }

        public string ErrorMessage { get; set; } = string.Empty;
        public List<T> Data { get; set; } = new List<T>();

        public string StackTrace { get; set; } = string.Empty;

    }
}
