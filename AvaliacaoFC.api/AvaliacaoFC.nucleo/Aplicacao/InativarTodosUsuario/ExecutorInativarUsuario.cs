using AvaliacaoFC.Nucleo.Aplicacao.InativarTodosUsuario;
using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario
{
    public class ExecutorInativarTodosUsuario : IRequestHandler<ComandoInativarTodosUsuario, RespostaInativarTodosUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorInativarTodosUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaInativarTodosUsuario> Handle(ComandoInativarTodosUsuario comando, CancellationToken cancellationToken)
        {
            var usuarios = _repositorioUsuario.ListarTodos().Where(x => x.Status != Usuario.Situacao.INATIVO);

            if (!usuarios.Any())
            {
                return Task.FromResult(RespostaInativarTodosUsuario.Invalido("Não existem usuários para inativar."));
            }

            foreach (var item in usuarios)
            {
                item.Inativar();
            }

            _repositorioUsuario.AtualizarLista(usuarios);

            _logger.LogInformation("Usuário inativado com sucesso!");

            return Task.FromResult(RespostaInativarTodosUsuario.Sucesso());
        }
    }
}
