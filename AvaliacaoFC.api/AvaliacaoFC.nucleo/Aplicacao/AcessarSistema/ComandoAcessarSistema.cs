using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema
{
    public class ComandoAcessarSistema : IRequest<RespostaAcessarSistema>
    {
        public string? Login { get; init; }
        public string? Senha { get; init; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorAcessarSistema().Validate(this);
            return validador;
        }
    }
}
