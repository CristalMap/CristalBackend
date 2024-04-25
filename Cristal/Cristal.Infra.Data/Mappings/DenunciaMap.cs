using Cristal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cristal.Infra.Data.Mappings
{
    public class DenunciaMap : IEntityTypeConfiguration<Denuncia>
    {
        public void Configure(EntityTypeBuilder<Denuncia> builder)
        {
            builder.ToTable("DENUNCIA");
            builder.HasKey(d => d.Guid);
            builder.Property(d => d.Guid).HasColumnName("GUID");
            builder.Property(d => d.Titulo).HasColumnName("TITULO").HasMaxLength(80).IsRequired();
            builder.Property(d => d.Descricao).HasColumnName("DESCRICAO").HasMaxLength(700).IsRequired();
            builder.HasOne(d => d.Endereco).WithMany(e => e.Denuncias).HasForeignKey(d => d.GuidEndereco);
            builder.Property(d => d.GuidEndereco).HasColumnName("GUIDENDERECO").IsRequired();
            builder.Property(d => d.FotoBase64).HasColumnName("FOTO").IsRequired();
            builder.Property(d => d.Status).HasColumnName("STATUS").IsRequired();
            builder.Property(d => d.DataHoraCriacao).HasColumnName("DATAHORACRIACAO").IsRequired();
            builder.Property(d => d.QuantidadeMamiferos).HasColumnName("QUANTIDADEMAMIFERO").IsRequired();
            builder.Property(d => d.QuantidadeAves).HasColumnName("QUANTIDADEAVES").IsRequired();
            builder.Property(d => d.QuantidadeRepteis).HasColumnName("QUANTIDADEREPTEIS").IsRequired();
            builder.Property(d => d.QuantidadePeixes).HasColumnName("QUANTIDADEANFIBIOS").IsRequired();
            builder.HasOne(d => d.Usuario).WithMany(u => u.Denuncias).HasForeignKey(d => d.GuidUsuario);
            builder.Property(d => d.GuidUsuario).HasColumnName("GUIDUSUARIO").IsRequired();
        }
    }
}
