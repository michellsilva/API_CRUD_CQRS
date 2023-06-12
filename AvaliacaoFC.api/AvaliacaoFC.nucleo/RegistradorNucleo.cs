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
using AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema;
using AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario;
using AvaliacaoFC.Nucleo.Infra.Servicos;

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

            servicos.AddTransient<IValidator<ComandoAcessarSistema>, ValidadorAcessarSistema>();
            servicos.AddTransient<IRequestHandler<ComandoAcessarSistema, RespostaAcessarSistema>, ExecutorAcessarSistema>();

            servicos.AddTransient<IValidator<ComandoRecuperarSenhaUsuario>, ValidadorRecuperarSenhaUsuario>();
            servicos.AddTransient<IRequestHandler<ComandoRecuperarSenhaUsuario, RespostaRecuperarSenhaUsuario>, ExecutorRecuperarSenhaUsuario>();

            servicos.AddScoped<IGeradorEmail>(_ => new GeradorEmail(
                configuracoes.GetValue<string>("configuracaoEmail:Provedor"),
                configuracoes.GetValue<int>("configuracaoEmail:Porta"),
                configuracoes.GetValue<string>("configuracaoEmail:EmailRemetente"),
                configuracoes.GetValue<string>("configuracaoEmail:NomeUsuario"),
                configuracoes.GetValue<string>("configuracaoEmail:Senha")));

            return servicos;
        }
    }
}
