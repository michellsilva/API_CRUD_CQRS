using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using AvaliacaoFC.Nucleo.Infra.Servicos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema
{
    public class ExecutorAcessarSistema : IRequestHandler<ComandoAcessarSistema, RespostaAcessarSistema>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IGeradorCriptografia _geradorCryptografia;
        public ExecutorAcessarSistema(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario, IGeradorCriptografia geradorCryptografia)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
            _geradorCryptografia = geradorCryptografia;
        }

        public Task<RespostaAcessarSistema> Handle(ComandoAcessarSistema comando, CancellationToken cancellationToken)
        {
            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaAcessarSistema.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            var usuario = _repositorioUsuario.ObterPorLoginESenha(comando.Login!, _geradorCryptografia.Criptografar(comando.Senha!));

            if (usuario == null)
            {
                return Task.FromResult(RespostaAcessarSistema.Invalido("Login ou Senha incorreto."));
            }

            _logger.LogInformation("Usuário logado com sucesso!");

            return Task.FromResult(RespostaAcessarSistema.Sucesso(usuario.Id, usuario.Nome));
        }
    }
}
