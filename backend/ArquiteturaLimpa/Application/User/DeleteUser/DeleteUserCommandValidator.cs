using FluentValidation;

namespace Application.User.DeleteUser;

public class DeleteUserCommandValidator : AbstractValidator<DeleteUserCommand>
{
    public DeleteUserCommandValidator()
    {
        RuleFor(v => v.Id).NotEmpty().NotEmpty();
    }
}
