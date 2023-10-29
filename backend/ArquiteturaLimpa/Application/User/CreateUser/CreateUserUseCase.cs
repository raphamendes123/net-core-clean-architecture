using Domain.Entities.User;
using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Validation;
using PearlCore.FieldValidation;
using Service.User;
using Service.User.Interface;

namespace Application.User.CreateUser;

public class CreateUserUseCase : Validator<CreateUserCommand>
{
    public CreateUserUseCase()
    {
        Add("IsCpfExist", new Rule<CreateUserCommand>(new IsCpfExist(), "Cpf: existing."));
        Add("IsCpfValid", new Rule<CreateUserCommand>(new IsCpfValid(), "Cpf: invalid."));
        Add("IsPasswordStrong", new Rule<CreateUserCommand>(new IsPasswordStrong(), "\r\nThe password must be strong \\r\\n It must contain 6 and 12 characters \\r\\n It must contain numbers \\r\\n It must have at least 1 uppercase letter \\r\\n It must have at least 1 lowercase letter. \\r\\n"));
        Add("IsEmailValid", new Rule<CreateUserCommand>(new IsEmailValid(), "Email: invalid."));
    }

    public class IsCpfValid : ISpecification<CreateUserCommand>
    {
        public bool IsSatisfiedBy(CreateUserCommand command)
        {
            return CpfValidation.IsValid((long)command.Cpf);
        }
    }
    public class IsCpfExist : ISpecification<CreateUserCommand>
    {
        private readonly IUserService userService;

        public IsCpfExist()
        {
            userService = new UserService();
        }

        public bool IsSatisfiedBy(CreateUserCommand command)
        {
            try
            {            
                return userService.FindFirst(new UserEntitie(cpf: command.Cpf)).Result.Data.Id == null;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
 
    public class IsPasswordStrong : ISpecification<CreateUserCommand>
    {
        public bool IsSatisfiedBy(CreateUserCommand command)
        {
            return PasswordStrongValidation.IsValid(command.Password);
        }
    }

    public class IsEmailValid : ISpecification<CreateUserCommand>
    {
        public bool IsSatisfiedBy(CreateUserCommand command)
        {
            return EmailValidation.IsValid(command.Email);
        }
    }
}

