using AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema;
using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario
{
    public class ExecutorRecuperarSenhaUsuario : IRequestHandler<ComandoRecuperarSenhaUsuario, RespostaRecuperarSenhaUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorRecuperarSenhaUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaRecuperarSenhaUsuario> Handle(ComandoRecuperarSenhaUsuario comando, CancellationToken cancellationToken)
        {
            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaRecuperarSenhaUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            var usuario = _repositorioUsuario.ObterPorEmail(comando.Email!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaRecuperarSenhaUsuario.Invalido("'E-mail' não encontrado."));
            }

            //TODO IMPLEMENTAR ENVIO DE EMAIL

            _logger.LogInformation("Usuário recuperou a senha com sucesso!");

            return Task.FromResult(RespostaRecuperarSenhaUsuario.Sucesso());
        }
    }
}
