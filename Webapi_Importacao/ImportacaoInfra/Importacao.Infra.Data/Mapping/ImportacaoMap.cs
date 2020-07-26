using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Webapi_Importacao.Domain.Entities;

namespace Webapi_Importacao.Infra.Data.Mapping
{
    public class ImportacaoMap : IEntityTypeConfiguration<Importacao>
    {
        public void Configure(EntityTypeBuilder<Importacao> builder)
        {
            builder.ToTable("Importacao");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.DataEntrega)
                .IsRequired()
                .HasColumnName("DataEntrega");

            builder.Property(c => c.NomeProduto)
                .IsRequired()
                .HasColumnName("NomeProduto");

            builder.Property(c => c.Quantidade)
                .IsRequired()
                .HasColumnName("Quantidade");

            builder.Property(c => c.ValorUnitario)
                .IsRequired()
                .HasColumnName("ValorUnitario");


        }
        

    }
}
