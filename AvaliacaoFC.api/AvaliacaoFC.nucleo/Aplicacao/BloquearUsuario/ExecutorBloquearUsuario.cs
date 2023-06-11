using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.BloquearUsuario
{
    public class ExecutorBloquearUsuario : IRequestHandler<ComandoBloquearUsuario, RespostaBloquearUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorBloquearUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaBloquearUsuario> Handle(ComandoBloquearUsuario comando, CancellationToken cancellationToken)
        {
            var usuario = _repositorioUsuario.ObterPorId((long)comando.Id!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaBloquearUsuario.Invalido("Usuário não encontrado."));
            }

            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaBloquearUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            usuario.Bloquear();

            _repositorioUsuario.AtualizarDados(usuario);


            _logger.LogInformation("Usuário bloqueado com sucesso!");

            return Task.FromResult(RespostaBloquearUsuario.Sucesso());
        }
    }
}
