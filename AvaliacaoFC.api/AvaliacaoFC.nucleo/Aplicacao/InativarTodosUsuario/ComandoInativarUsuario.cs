using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.InativarTodosUsuario
{
    public class ComandoInativarTodosUsuario : IRequest<RespostaInativarTodosUsuario>
    {
        public ValidationResult Validar()
        {
            var validador = new ValidadorInativarTodosUsuario().Validate(this);
            return validador;
        }
    }   
}
