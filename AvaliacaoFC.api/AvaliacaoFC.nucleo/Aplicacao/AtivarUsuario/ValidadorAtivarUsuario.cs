using FluentValidation;

namespace AvaliacaoFC.Nucleo.Aplicacao.AtivarUsuario
{
    public class ValidadorAtivarUsuario : AbstractValidator<ComandoAtivarUsuario>
    {
        public ValidadorAtivarUsuario()
        {
            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'Id' deve ser informado.")
               .NotEmpty().WithMessage("O 'Id' deve ser informado.");
        }
    }
}
