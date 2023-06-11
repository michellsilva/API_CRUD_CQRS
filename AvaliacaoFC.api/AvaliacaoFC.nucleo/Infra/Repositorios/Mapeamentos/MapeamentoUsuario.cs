using AvaliacaoFC.Nucleo.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvaliacaoFC.Nucleo.Infra.Repositorios.Mapeamentos
{
    public class MapeamentoUsuario : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("usuario");

            builder.HasKey(x => x.Id);


        }
    }
}
