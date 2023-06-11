using FluentValidation.Results;
using MediatR;

namespace AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario
{
    public class ComandoAtualizarUsuario : IRequest<RespostaAtualizarUsuario>
    {
        public long? Id { get; init; }
        public string? Nome { get; init; }
        public string? Login { get; init; }
        public string? Email { get; init; }
        public string? Telefone { get; init; }
        public string? Cpf { get; init; }
        public DateTime DataNascimento { get; init; }
        public string? NomeMae { get; init; }
        public int? Status { get; init; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorAtualizarUsuario().Validate(this);
            return validador;
        }
    }
}
