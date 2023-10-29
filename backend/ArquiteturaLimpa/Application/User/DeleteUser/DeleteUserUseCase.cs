using Application.Common.Exceptions;
using Domain.Entities.User;
using DomainValidationCore.Interfaces.Specification;
using DomainValidationCore.Validation;
using Service.User;
using Service.User.Interface;
using System;

namespace Application.User.DeleteUser;

public class DeleteUserUseCase : Validator<DeleteUserCommand>
{
    public DeleteUserUseCase()
    {
        Add("Id", new Rule<DeleteUserCommand>(new IsIdNoExist(), "Id: no exist."));
    }
}
 
public class IsIdNoExist : ISpecification<DeleteUserCommand>
{
    private readonly IUserService userService;

    public IsIdNoExist()
    {
        this.userService = new UserService();
    }
    public bool IsSatisfiedBy(DeleteUserCommand model)
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
