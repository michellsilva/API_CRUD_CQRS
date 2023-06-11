using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios.Mapeamentos;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuarios => Set<Usuario>();


        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MapeamentoUsuario());
        }
    }
}
