using FluentValidation;

namespace Application.Autentication;

public class AutenticationCommandValidator : AbstractValidator<AutenticationCommand>
{
    public AutenticationCommandValidator()
    {
        RuleFor(v => v.Cpf).NotEmpty().NotEqual(10).NotEmpty();
        RuleFor(v => v.Cpf).NotEmpty().NotEqual(10).NotEmpty();
    }
}
