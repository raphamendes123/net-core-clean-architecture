
using Application.Common.Exceptions;
using Domain.Entities.User;
using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Validation;
using PearlCore.FieldValidation;
using Service.User;
using Service.User.Interface;

namespace Application.User.UpdateUser;

public class UpdateUserUseCase : Validator<UpdateUserCommand>
{
    public UpdateUserUseCase()
    {
        Add("IsIdNoExist", new Rule<UpdateUserCommand>(new IsIdNoExist(), "Id: no exist.")); 
    }

    public class IsIdNoExist : ISpecification<UpdateUserCommand>
    {
        private readonly IUserService userService;

        public IsIdNoExist()
        {
            this.userService = new UserService();
        }
        public bool IsSatisfiedBy(UpdateUserCommand model)
        {
            try
            {
                return (userService.FindFirst(new UserEntitie(id: model.Id)).Result.Data.Id == null ? throw new NotFoundException() : true);
            }
            catch (Exception exception)
            {
                throw new NotFoundException("Id: no exist", exception);
            }
        }
    }

}

