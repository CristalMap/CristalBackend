using Cristal.Domain.Models;
using Cristal.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Cristal.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=;Database=;User Id=;Password=;");
            //optionsBuilder.UseSqlServer(@"Data Source=(localdb)\Servidor;Initial Catalog=Cristal;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new DenunciaMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
        }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Denuncia> Denuncia { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
    }
}
