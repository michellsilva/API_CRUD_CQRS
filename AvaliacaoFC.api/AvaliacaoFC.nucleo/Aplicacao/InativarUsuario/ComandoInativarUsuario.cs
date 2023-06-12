using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario
{
    public class ComandoInativarUsuario : IRequest<RespostaInativarUsuario>
    {
        public long? Id { get; set; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorInativarUsuario().Validate(this);
            return validador;
        }
    }   
}
