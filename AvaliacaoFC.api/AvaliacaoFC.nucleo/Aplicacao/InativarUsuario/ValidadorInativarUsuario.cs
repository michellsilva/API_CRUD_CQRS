﻿using FluentValidation;

namespace AvaliacaoFC.Nucleo.Aplicacao.InativarUsuario
{
    public class ValidadorInativarUsuario : AbstractValidator<ComandoInativarUsuario>
    {
        public ValidadorInativarUsuario()
        {
            RuleFor(x => x.Id)
               .Cascade(CascadeMode.Stop)
               .NotNull().WithMessage("O 'Id' deve ser informado.")
               .NotEmpty().WithMessage("O 'Id' deve ser informado.");
        }
    }
}
