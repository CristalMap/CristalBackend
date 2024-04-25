using Cristal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cristal.Infra.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("ENDERECO");
            builder.HasKey(e => e.Guid);
            builder.Property(e => e.Guid).HasColumnName("GUID");
            builder.Property(e => e.Nome).HasColumnName("NOME").IsRequired();
            builder.Property(e => e.Latitude).HasColumnName("LATITUDE").IsRequired();
            builder.Property(e => e.Longitude).HasColumnName("LONGITUDE").IsRequired();
        }
    }
}
