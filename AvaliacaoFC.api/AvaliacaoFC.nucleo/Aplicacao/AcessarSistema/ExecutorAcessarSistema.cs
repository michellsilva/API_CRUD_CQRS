using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema
{
    public class ExecutorAcessarSistema : IRequestHandler<ComandoAcessarSistema, RespostaAcessarSistema>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorAcessarSistema(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaAcessarSistema> Handle(ComandoAcessarSistema comando, CancellationToken cancellationToken)
        {
            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaAcessarSistema.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            var usuario = _repositorioUsuario.ObterPorLoginESenha(comando.Login!, comando.Senha!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaAcessarSistema.Invalido("Usuário não encontrado."));
            }

            _logger.LogInformation("Usuário logado com sucesso!");

            return Task.FromResult(RespostaAcessarSistema.Sucesso());
        }
    }
}
