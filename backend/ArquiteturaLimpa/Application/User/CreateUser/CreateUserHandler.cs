using Application.Common.Exceptions;
using Application.Common.Validator;
using AutoMapper;
using Domain.Entities.User;
using Infrastructure.Common.Api;
using MediatR;
using Repository.Common;
using Service.User;
using Service.User.Interface;

namespace Application.User.CreateUser;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, Response<long>>
{
    private readonly IMapper mapper;
    private readonly IUserService userService;
  
    public CreateUserHandler(IMapper mapper)
    {
        this.userService = new UserService(new UnitOfWorkService().OpenTransaction());
        this.mapper = mapper;
    }

    public async Task<Response<long>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validate = new CreateUserUseCase().Validate(request);

        if (!validate.IsValid)
            throw new ValidationException(validate.Errors.ToValidationFailure());

        var user = mapper.Map<UserEntitie>(request);
         
        this.userService.unitOfWork?.BeginTransaction();

        var result = await userService.Create(user);

        this.userService.unitOfWork?.Complete();

        return new Response<long> { Data = result.Data };
    }
}
