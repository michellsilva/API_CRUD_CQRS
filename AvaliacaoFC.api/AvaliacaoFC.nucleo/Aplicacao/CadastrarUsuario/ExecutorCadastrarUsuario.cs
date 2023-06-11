using AvaliacaoFC.Nucleo.Aplicacao.ListarUsuarios;
using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AvaliacaoFC.Nucleo.Dominio.Usuario;

namespace AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario
{
    public class ExecutorCadastrarUsuario : IRequestHandler<ComandoCadastrarUsuario, RespostaCadastrarUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        public ExecutorCadastrarUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
        }

        public Task<RespostaCadastrarUsuario> Handle(ComandoCadastrarUsuario comando, CancellationToken cancellationToken)
        {
            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaCadastrarUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            var usuario = new Usuario(
                comando.Nome!,
                comando.Login!,
                comando.Senha!,
                comando.Email!,
                comando.Telefone!,
                comando.Cpf!,
                comando.DataNascimento,
                comando.NomeMae!
            );

            if (_repositorioUsuario.UsuarioJaCadastrado(usuario))
            {
                return Task.FromResult(RespostaCadastrarUsuario.Invalido("Usuário já cadastro no sistema."));
            }

            _repositorioUsuario.Casdastrar(usuario);

            _logger.LogInformation("Usuário cadastrado com sucesso!");

            return Task.FromResult(RespostaCadastrarUsuario.Sucesso());
        }
    }
}
