using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                .MinimumLength(5).WithMessage("O 'Nome de usuário' deve conter no mínimo 5 caracteres.")
                .MaximumLength(150).WithMessage("O 'Nome de usuário' ultrapassou o limite máximo de caracteres.");

            RuleFor(x => x.Login)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'Login' deve ser informado.")
               .NotEmpty().WithMessage("O 'Login' deve ser informado.")
               .MinimumLength(5).WithMessage("O 'Login' deve conter no mínimo 5 caracteres.")
               .MaximumLength(30).WithMessage("O 'Login' ultrapassou o limite máximo de caracteres.");

            RuleFor(x => x.Email)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'E-mail' deve ser informado.")
               .NotEmpty().WithMessage("O 'E-mail' deve ser informado.")
               .MaximumLength(150).WithMessage("O 'E-mail' ultrapassou o limite máximo de caracteres.")
               .EmailAddress().WithMessage("O 'E-mail' no formato inválido.");

            RuleFor(x => x.Senha)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("A 'Senha' deve ser informado.")
              .NotEmpty().WithMessage("A 'Senha' deve ser informado.")
              .MinimumLength(8).WithMessage("A 'Senha' deve conter no mínimo 5 caracteres.")
              .MaximumLength(20).WithMessage("A 'Senha' ultrapassou o limite máximo de caracteres.");

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
             .NotNull().WithMessage("A 'Data de Nascimento' deve ser informado.")
             .NotEmpty().WithMessage("A 'Data de Nascimento' deve ser informado.");

            RuleFor(x => x.NomeMae)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("O 'Nome da Mãe' deve ser informado.")
            .NotEmpty().WithMessage("O 'Nome da Mãe' deve ser informado.");

        }
    }
}
