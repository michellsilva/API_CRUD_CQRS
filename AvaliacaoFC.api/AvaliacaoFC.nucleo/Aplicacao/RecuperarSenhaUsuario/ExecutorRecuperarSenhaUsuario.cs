using AvaliacaoFC.Nucleo.Dominio;
using AvaliacaoFC.Nucleo.Infra.Repositorios;
using AvaliacaoFC.Nucleo.Infra.Servicos;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario
{
    public class ExecutorRecuperarSenhaUsuario : IRequestHandler<ComandoRecuperarSenhaUsuario, RespostaRecuperarSenhaUsuario>
    {
        private readonly ILogger<Usuario> _logger;
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IGeradorEmail _geradorEmail;
        private readonly IGeradorTemplate _GeradorTemplate;
        private readonly IGeradorCriptografia _geradorCryptografia;

        public ExecutorRecuperarSenhaUsuario(ILogger<Usuario> logger, IRepositorioUsuario repositorioUsuario,
            IGeradorEmail geradorEmail, IGeradorTemplate geradorTemplate, IGeradorCriptografia geradorCryptografia)
        {
            _logger = logger;
            _repositorioUsuario = repositorioUsuario;
            _geradorEmail = geradorEmail;
            _GeradorTemplate = geradorTemplate;
            _geradorCryptografia = geradorCryptografia;
        }

        public Task<RespostaRecuperarSenhaUsuario> Handle(ComandoRecuperarSenhaUsuario comando, CancellationToken cancellationToken)
        {
            if (!comando.Validar().IsValid)
            {
                return Task.FromResult(RespostaRecuperarSenhaUsuario.Invalido(comando.Validar().Errors.First().ErrorMessage));
            }

            var usuario = _repositorioUsuario.ObterPorEmail(comando.Email!);

            if (usuario == null)
            {
                return Task.FromResult(RespostaRecuperarSenhaUsuario.Invalido("'E-mail' não encontrado."));
            }

            var template = _GeradorTemplate.GerarTemplate(new[] { _geradorCryptografia.Descriptografar(usuario.Senha) }, "RecuperarSenha");

            _geradorEmail.Enviar(new[] { usuario.Email }, "Recuperação de senha", template, null);

            _logger.LogInformation("Usuário recuperou a senha com sucesso!");

            return Task.FromResult(RespostaRecuperarSenhaUsuario.Sucesso());
        }
    }
}
