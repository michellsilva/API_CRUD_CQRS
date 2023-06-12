using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios;
using AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario;
using FluentValidation;
using AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.AtivarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.BloquearUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.BloquearsUsuario;
using AvaliacaoFC.Nucleo.Aplicacao.InativarTodosUsuario;

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

            servicos.AddTransient<IValidator<ComandoInativarUsuario>, ValidadorInativarUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoInativarUsuario, RespostaInativarUsuario>, ExecutorInativarUsuario>();

            servicos.AddTransient<IValidator<ComandoBloquearUsuario>, ValidadorBloquearUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoBloquearUsuario, RespostaBloquearUsuario>, ExecutorBloquearUsuario>();

            servicos.AddTransient<IValidator<ComandoInativarTodosUsuario>, ValidadorInativarTodosUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoInativarTodosUsuario, RespostaInativarTodosUsuario>, ExecutorInativarTodosUsuario>();

            servicos.AddTransient<IValidator<ComandoAtivarUsuario>, ValidadorAtivarUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoAtivarUsuario, RespostaAtivarUsuario>, ExecutorAtivarUsuario>();

            return servicos;
        }
    }
}
