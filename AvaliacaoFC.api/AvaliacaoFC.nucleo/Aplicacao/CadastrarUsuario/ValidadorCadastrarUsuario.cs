using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace AvaliacaoFC.Nucleo.Aplicacao.CadastrarUsuario
{
    public class ValidadorCadastrarUsuario : AbstractValidator<ComandoCadastrarUsuario>
    {
        public ValidadorCadastrarUsuario()
        {
            RuleFor(x => x.Nome)
                .Cascade(CascadeMode.Stop)
                .NotNull().WithMessage("O 'Nome de usuário' deve ser informado.")
                .NotEmpty().WithMessage("O 'Nome de usuário' deve ser informado.")
                .Length(5, 150).WithMessage("O 'Nome de usuário' deve ter no mínimo 5 caracteres e no máximo 150 caracteres.");

            RuleFor(x => x.Login)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'Login' deve ser informado.")
               .NotEmpty().WithMessage("O 'Login' deve ser informado.")
               .Length(5, 20).WithMessage("O 'Login' deve ter no mínimo 5 caracteres e no máximo 20 caracteres.");

            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'E-mail' deve ser informado.")
               .NotEmpty().WithMessage("O 'E-mail' deve ser informado.")
               .MaximumLength(150).WithMessage("O 'E-mail' ultrapassou o limite máximo de caracteres.")
               .EmailAddress().WithMessage("O 'E-mail' esta no formato inválido.");
            
            RuleFor(x => x.Senha!)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("A 'Senha' deve ser informada.")
              .NotEmpty().WithMessage("A 'Senha' deve ser informada.")
              .Must(value =>
                Regex.IsMatch(value, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,20}$"))
              .WithMessage("A 'Senha' deve conter (letra maiúscula, letra minúscula, número, caracater especial) enrte 8 a 20 caracteres.");

            RuleFor(x => x.Telefone)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("O 'Telefone' deve ser informado.")
              .NotEmpty().WithMessage("O 'Telefone' deve ser informado.");

            RuleFor(x => x.Cpf)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("O 'CPF' deve ser informado.")
              .NotEmpty().WithMessage("O 'CPF' deve ser informado.");

            RuleFor(x => x.DataNascimento)
             .Cascade(CascadeMode.Stop)
             .NotNull().WithMessage("A 'Data de Nascimento' deve ser informada.")
             .NotEmpty().WithMessage("A 'Data de Nascimento' deve ser informada.");

            RuleFor(x => x.NomeMae)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("O 'Nome da Mãe' deve ser informado.")
            .NotEmpty().WithMessage("O 'Nome da Mãe' deve ser informado.");

        }
    }
}
