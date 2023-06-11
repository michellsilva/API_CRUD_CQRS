using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario
{
    public class ExecutorAtualizarUsuario : IRequestHandler<ComandoAtualizarUsuario, RespostaAtualizarUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorAtualizarUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaAtualizarUsuario> Handle(ComandoAtualizarUsuario comando, CancellationToken cancellationToken)
        {
            var usuario = _repositorioUsuario.ObterPorId((long)comando.Id!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaAtualizarUsuario.Invalido("Usuário não encontrado."));
            }

            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaAtualizarUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            usuario!.AtualizarDados(
                comando.Nome!,
                comando.Login!,
                comando.Email!,
                comando.Telefone!,
                comando.Cpf!,
                comando.DataNascimento,
                comando.NomeMae!,
                (Usuario.Situacao)comando.Status!
            );

            _repositorioUsuario.AtualizarDados(usuario);

            _logger.LogInformation("Usuário atualizado com sucesso!");

            return Task.FromResult(RespostaAtualizarUsuario.Sucesso());
        }
    }
}
