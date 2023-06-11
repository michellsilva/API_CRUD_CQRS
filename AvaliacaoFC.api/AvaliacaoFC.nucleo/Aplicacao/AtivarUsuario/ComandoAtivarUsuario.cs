using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.AtivarUsuario
{
    public class ComandoAtivarUsuario : IRequest<RespostaAtivarUsuario>
    {
        public long? Id { get; set; }
        public int? Status { get; init; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorAtivarUsuario().Validate(this);
            return validador;
        }
    }   
}
