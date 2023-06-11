using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios;
using AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario;
using FluentValidation;
using AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario;

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

            servicos.AddTransient<IValidator<ComandoAtualizarUsuario>, ValidadorAtualizarUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoAtualizarUsuario, RespostaAtualizarUsuario>, ExecutorAtualizarUsuario>();


            return servicos;
        }
    }
}
