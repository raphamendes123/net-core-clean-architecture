using Application.Common.Exceptions;
using Application.Common.Validator;
using AutoMapper;
using Domain.Entities.User;
using Infrastructure.Common.Api;
using MediatR;
using Repository.Common;
using Service.User;
using Service.User.Interface;

namespace Application.User.DeleteUser;

public class DeleteUserHandler : IRequestHandler<DeleteUserCommand, Response<bool>>
{
    private readonly IMapper mapper;
    private readonly IUserService userService;

    public DeleteUserHandler(IMapper mapper)
    {
        this.userService = new UserService(new UnitOfWorkService().OpenTransaction());
        this.mapper = mapper;
    }

    public async Task<Response<bool>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var validate = new DeleteUserUseCase().Validate(request);

        if (!validate.IsValid)
            throw new ValidationException(validate.Errors.ToValidationFailure());

        var user = mapper.Map<UserEntitie>(request);

        this.userService.unitOfWork?.BeginTransaction();

        var result = await userService.Delete((long)user.Id);

        this.userService.unitOfWork?.Complete();

        return new Response<bool> { Data = result.Data};
    }
}
