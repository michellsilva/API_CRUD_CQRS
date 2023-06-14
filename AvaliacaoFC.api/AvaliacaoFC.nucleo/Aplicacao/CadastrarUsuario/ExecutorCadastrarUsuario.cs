using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using AvaliacaoFC.Nucleo.Infra.Servicos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario
{
    public class ExecutorCadastrarUsuario : IRequestHandler<ComandoCadastrarUsuario, RespostaCadastrarUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IGeradorCriptografia _geradorCryptografia;
        public ExecutorCadastrarUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario, IGeradorCriptografia geradorCryptografia)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
            _geradorCryptografia = geradorCryptografia;
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
                _geradorCryptografia.Criptografar(comando.Senha!),
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
