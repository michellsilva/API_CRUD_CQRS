using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios
{
    public class ExecutorListarUsuarios : IRequestHandler<ConsultaListarUsuarios, RespostaListarUsuarios>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorListarUsuarios(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaListarUsuarios> Handle(ConsultaListarUsuarios coamando, CancellationToken cancellationToken)
        {
            var usuarios = _repositorioUsuario.ListarTodos();

            return Task.FromResult(RespostaListarUsuarios.Sucesso(usuarios));
        }
    }
}
