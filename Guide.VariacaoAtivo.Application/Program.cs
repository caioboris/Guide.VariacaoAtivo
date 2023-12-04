using Guide.VariacaoAtivo.Application.Services;
using Guide.VariacaoAtivo.Context;
using Guide.VariacaoAtivo.Data.Repositories;
using Guide.VariacaoAtivo.Domain.Interfaces.Repositories;
using Guide.VariacaoAtivo.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IAtivoRepository, AtivoRepository>();
builder.Services.AddScoped<IAtivoService, AtivoService>();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    .LogTo(Console.WriteLine, LogLevel.Information);
    
});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
