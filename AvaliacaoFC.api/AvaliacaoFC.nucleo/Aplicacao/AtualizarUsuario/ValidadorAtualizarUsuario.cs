using FluentValidation;

namespace AvaliacaoFC.Nucleo.Aplicacao.AtualizarUsuario
{
    public class ValidadorAtualizarUsuario : AbstractValidator<ComandoAtualizarUsuario>
    {
        public ValidadorAtualizarUsuario()
        {
            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'Id' deve ser informado.")
               .NotEmpty().WithMessage("O 'Id' deve ser informado.");

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
               .EmailAddress().WithMessage("O 'E-mail' no formato inválido.");

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

            RuleFor(x => x.Status)
            .Cascade(CascadeMode.Stop)
            .NotNull().WithMessage("O 'Status' deve ser informado.")
            .NotEmpty().WithMessage("O 'Status' deve ser informado.");

        }
    }
}
