using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios;
using AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario;
using FluentValidation;
using AvaliacaoFC.Nucleo.Aplicacao;

namespace AvaliacaoFC.Nucleo
{
    public static class RegistradorNucleo
    {
        public static IServiceCollection AdicionarNucleo(this IServiceCollection servicos, IConfigurationRoot configuracoes)
        {
            servicos.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

            servicos.AddTransient<IRequestHandler<ConsultaListarUsuarios, RespostaListarUsuarios>, ExecutorListarUsuarios>();

            servicos.AddTransient<IValidator<ComandoCadastrarUsuario>, ValidadorCadastrarUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoCadastrarUsuario, RespostaCadastrarUsuario>, ExecutorCadastrarUsuario>();
            


            return servicos;
        }
    }
}
