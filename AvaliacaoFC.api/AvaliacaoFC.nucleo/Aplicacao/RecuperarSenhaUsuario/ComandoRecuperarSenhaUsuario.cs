using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario
{
    public class ComandoRecuperarSenhaUsuario : IRequest<RespostaRecuperarSenhaUsuario>
    {
        public string? Email { get; init; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorRecuperarSenhaUsuario().Validate(this);
            return validador;
        }
    }
}
