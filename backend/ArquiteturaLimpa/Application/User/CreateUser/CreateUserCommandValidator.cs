using FluentValidation;

namespace Application.User.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(v => v.Name).MaximumLength(50).NotEmpty();
        RuleFor(v => v.Surname).MaximumLength(50).NotEmpty();
        RuleFor(v => v.DisplayName).MaximumLength(50).NotEmpty();
    }
}
