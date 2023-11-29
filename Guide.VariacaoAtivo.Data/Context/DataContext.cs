using Guide.VariacaoAtivo.Configuration;
using Guide.VariacaoAtivo.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Guide.VariacaoAtivo.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Ativo>(new AtivosConfiguration().Configure);
            base.OnModelCreating(builder);
        }

        public DbSet<Ativo> Ativos { get; set; }

    }
}
