using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario
{
    public class ComandoCadastrarUsuario : IRequest<RespostaCadastrarUsuario>
    {
        public string? Nome { get; init; }
        public string? Login { get; init; }
        public string? Senha { get; init; }
        public string? Email { get; init; }
        public string? Telefone { get; init; }
        public string? Cpf { get; init; }
        public DateTime DataNascimento { get; init; }
        public string? NomeMae { get; init; }

        public ValidationResult Validar()
        {
            var validador = new ValidadorCadastrarUsuario().Validate(this);
            return validador;
        }
    }
}
