using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario
{
    public class ExecutorInativarUsuario : IRequestHandler<ComandoInativarUsuario, RespostaInativarUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorInativarUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaInativarUsuario> Handle(ComandoInativarUsuario comando, CancellationToken cancellationToken)
        {
            var usuario = _repositorioUsuario.ObterPorId((long)comando.Id!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaInativarUsuario.Invalido("Usuário não encontrado."));
            }

            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaInativarUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            usuario.Inativar();

            _repositorioUsuario.AtualizarDados(usuario);


            _logger.LogInformation("Usuário inativado com sucesso!");

            return Task.FromResult(RespostaInativarUsuario.Sucesso());
        }
    }
}
