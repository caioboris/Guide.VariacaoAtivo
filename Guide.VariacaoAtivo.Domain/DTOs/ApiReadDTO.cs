namespace Guide.VariacaoAtivo.Domain.DTOs
{
    public record RootObject(Chart Chart);
    public record Chart(List<Result> Result, string Error);
    public record Result(long[] Timestamp, Indicators Indicators);
    public record Indicators(List<Quote> Quote);
    public record Quote(long[] Volume, decimal[] Open, decimal[] High, decimal[] Close, decimal[] Low);

}
