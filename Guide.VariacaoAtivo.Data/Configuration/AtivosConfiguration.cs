using Guide.VariacaoAtivo.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Guide.VariacaoAtivo.Configuration
{
    public class AtivosConfiguration : IEntityTypeConfiguration<Ativo>
    {
        public void Configure(EntityTypeBuilder<Ativo> builder)
        {
            builder.ToTable("TB_VARIACAO_ATIVOS");
            builder.HasKey(t => t.Id);

            builder.Property(x => x.VariacaoPrimeiraData)
                .HasColumnType("DECIMAL(8, 6)")
                .IsRequired();

            builder.Property(x => x.VariacaoDiaAnterior)
                .HasColumnType("DECIMAL(8, 6)")
                .IsRequired();

            builder.Property(x => x.Valor)
                .HasColumnType("DECIMAL(6, 3)")
                .IsRequired();

            builder.Property(t => t.Data)
                .HasColumnType("DATETIME");
        }
    }
}
