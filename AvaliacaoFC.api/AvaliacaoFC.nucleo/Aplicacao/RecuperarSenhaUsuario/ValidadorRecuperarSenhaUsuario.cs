using AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaliacaoFC.Nucleo.Aplicacao.RecuperarSenhaUsuario
{
    public class ValidadorRecuperarSenhaUsuario : AbstractValidator<ComandoRecuperarSenhaUsuario>
    {
        public ValidadorRecuperarSenhaUsuario()
        {
            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'E-mail' deve ser informado.")
               .NotEmpty().WithMessage("O 'E-mail' deve ser informado.")
               .MaximumLength(150).WithMessage("O 'E-mail' ultrapassou o limite máximo de caracteres.")
               .EmailAddress().WithMessage("O 'E-mail' esta no formato inválido.");
        }
    }
}
