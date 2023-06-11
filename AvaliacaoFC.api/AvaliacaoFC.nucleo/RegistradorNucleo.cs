using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace AvaliacaoFC.Nucleo
{
    public static class RegistradorNucleo
    {
        public static IServiceCollection AdicionarNucleo(this IServiceCollection servicos, IConfigurationRoot configuracoes)
        {
            servicos
                .AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            return servicos;
        }
    }
}
