using FluentValidation;

namespace Application.User.UpdateUser;

public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(v => v.Name).MaximumLength(50).NotEmpty();
        RuleFor(v => v.Surname).MaximumLength(50).NotEmpty();
        RuleFor(v => v.DisplayName).MaximumLength(50).NotEmpty();
    }
}
