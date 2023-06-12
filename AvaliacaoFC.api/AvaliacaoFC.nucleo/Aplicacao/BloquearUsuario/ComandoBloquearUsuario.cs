using AvaliacaoFC.Nucleo.Aplicacao.BloquearsUsuario;
using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.BloquearUsuario
{
    public class ComandoBloquearUsuario : IRequest<RespostaBloquearUsuario>
    {
        public long? Id { get; init; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorBloquearUsuario().Validate(this);
            return validador;
        }
    }   
}
