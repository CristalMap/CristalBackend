using Cristal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cristal.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");
            builder.HasKey(u => u.Guid);
            builder.Property(u => u.Guid).HasColumnName("GUID");
            builder.Property(u => u.Nome).HasColumnName("NOME").HasMaxLength(80).IsRequired();
            builder.Property(u => u.Email).HasColumnName("EMAIL").HasMaxLength(200).IsRequired();
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.Telefone).HasColumnName("TELEFONE").HasMaxLength(11).IsRequired();
            builder.Property(u => u.Senha).HasColumnName("SENHA").HasMaxLength(255).IsRequired();
            builder.Property(u => u.DatahoraCriacao).HasColumnName("DATAHORACRIACAO").IsRequired();
            builder.Property(u => u.Pontos).HasColumnName("PONTO").IsRequired();
            builder.Property(u => u.Foto).HasColumnName("FOTO");
            builder.Property(u => u.Administrador).HasColumnName("ADMINISTRADOR").IsRequired();
        }
    }
}
