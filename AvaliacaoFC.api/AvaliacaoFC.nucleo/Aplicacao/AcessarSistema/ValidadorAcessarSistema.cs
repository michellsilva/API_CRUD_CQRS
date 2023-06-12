using FluentValidation;

namespace AvaliacaoFC.Nucleo.Aplicacao.AcessarSistema
{
    public class ValidadorAcessarSistema : AbstractValidator<ComandoAcessarSistema>
    {
        public ValidadorAcessarSistema()
        {
            RuleFor(x => x.Login)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'Login' deve ser informado.")
               .NotEmpty().WithMessage("O 'Login' deve ser informado.");

            RuleFor(x => x.Senha)
              .Cascade(CascadeMode.Stop)
              .NotNull().WithMessage("A 'Senha' deve ser informada.")
              .NotEmpty().WithMessage("A 'Senha' deve ser informada.");
        }
    }
}
