using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.AtivarUsuario
{
    public class ExecutorAtivarUsuario : IRequestHandler<ComandoAtivarUsuario, RespostaAtivarUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorAtivarUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaAtivarUsuario> Handle(ComandoAtivarUsuario comando, CancellationToken cancellationToken)
        {
            var usuario = _repositorioUsuario.ObterPorId((long)comando.Id!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaAtivarUsuario.Invalido("Usuário não encontrado."));
            }

            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaAtivarUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            usuario.Ativar();

            _repositorioUsuario.AtualizarDados(usuario);


            _logger.LogInformation("Usuário ativado com sucesso!");

            return Task.FromResult(RespostaAtivarUsuario.Sucesso());
        }
    }
}
