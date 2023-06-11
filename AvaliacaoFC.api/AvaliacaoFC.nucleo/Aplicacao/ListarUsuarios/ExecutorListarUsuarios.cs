using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
